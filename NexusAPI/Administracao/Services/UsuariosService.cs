using Microsoft.Identity.Client.Extensibility;
using Microsoft.IdentityModel.Tokens;
using NexusAPI.Administracao.DTOs;
using NexusAPI.Administracao.Exceptions;
using NexusAPI.Administracao.Models;
using NexusAPI.Administracao.Repositories;
using NexusAPI.Compartilhado.EntidadesBase;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NexusAPI.Administracao.Services
{
    public class UsuariosService : BaseService<UsuarioEnvioDTO, UsuarioRespostaDTO, Usuario>
    {
        private readonly IConfiguration configuration;

        public UsuariosService(UsuarioRepository repository, IConfiguration configuration) 
        : base(repository)
        {
            this.configuration = configuration;
        }

        public override Usuario ConverterParaClasse(UsuarioEnvioDTO obj)
        {
            var resposta = new Usuario()
            {
                NomeAcesso = obj.NomeAcesso ?? "",
                Nome = obj.Nome ?? "",
                Descricao = obj.Descricao ?? "",
                Senha = obj.Senha ?? ""
            };

            return resposta;
        }

        public override async Task<UsuarioRespostaDTO> ConverterParaDTORespostaAsync(Usuario obj)
        {
            var resposta = new UsuarioRespostaDTO()
            {
                NomeAcesso = obj.NomeAcesso,
                UID = obj.UID,
                Nome = obj.Nome,
                Descricao = obj.Descricao,
                AtualizadoPor = new BaseNomeObjeto()
                {
                    UID = obj.AtualizadoPorUID,
                    Nome = obj.AtualizadoPorUID != null ?
                        await ObterNomePorUIDAsync(obj.AtualizadoPorUID) : null
                },
                UsuarioCriador = new BaseNomeObjeto()
                {
                    UID = obj.UsuarioCriadorUID,
                    Nome = obj.UsuarioCriadorUID != null ?
                        await ObterNomePorUIDAsync(obj.UsuarioCriadorUID) : null
                },
                DataCriacao = obj.DataCriacao
            };

            return resposta;
        }

        public async override Task<UsuarioRespostaDTO> AdicionarAsync(UsuarioEnvioDTO usuarioDTO)
        {
            var usuarioRepository = repository as UsuarioRepository;

            //Converte repository para UsuarioRepository para utilizar método especifico.
            if (usuarioRepository == null)
            {
                throw new Exception("Instância incorreta em 'repository'.");
            }

            var usuarioBD = await usuarioRepository.ObterPorNomeAcessoAsync(usuarioDTO.NomeAcesso);

            if (usuarioBD != null)
            {
                throw new NomeAcessoJaCadastrado();
            }

            var usuario = ConverterParaClasse(usuarioDTO);

            usuario.UID = Guid.NewGuid().ToString();
            usuario.Senha = BCrypt.Net.BCrypt.HashPassword(usuario.Senha);
            usuario.UsuarioCriadorUID = null;

            var dtoResposta = await ConverterParaDTORespostaAsync(await repository.AdicionarAsync(usuario));
            dtoResposta.Token = new TokenDTO(GerarToken(dtoResposta.UID, dtoResposta.NomeAcesso));

            return dtoResposta;
        }

        /// <summary>
        /// Autentica o usuário e retorna o token JWT.
        /// </summary>
        /// <param name="usuarioEnvio"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        /// <exception cref="CredenciaisIncorretas"></exception>
        public async Task<TokenDTO> AutenticarUsuario(UsuarioEnvioDTO usuarioEnvio)
        {
            var usuarioRepository = repository as UsuarioRepository;

            //Converte repository para UsuarioRepository para utilizar metodo especifico.
            if (usuarioRepository == null)
            {
                throw new Exception("Instância incorreta em 'repository'.");
            }

            var usuario = await usuarioRepository.ObterPorNomeAcessoAsync(usuarioEnvio.NomeAcesso);

            //Se o usuario não existe ou a senha for incorreta.
            if (usuario == null || !BCrypt.Net.BCrypt.Verify(usuarioEnvio.Senha, usuario.Senha))
            {
                throw new CredenciaisIncorretas();
            }

            return new TokenDTO(GerarToken(usuario.UID, usuario.NomeAcesso));
        }

        public string GerarToken(string usuarioUID, string nomeAcesso)
        {
            //Cria as claims conforme UID e nomeAcesso do usuário.
            var claims = new[]
            {
                new Claim("UID", usuarioUID),
                new Claim("nomeAcesso", nomeAcesso),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var chaveSecreta = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(configuration["Logging:Auth:chave"]));

            var credenciais = new SigningCredentials(chaveSecreta, SecurityAlgorithms.HmacSha256);
            var expiracao = DateTime.Now.AddMinutes(30);

            //Cria token que irá se expirar em 30 minutos.
            var token = new JwtSecurityToken(
                issuer: configuration["Logging:Auth:issuer"],
                audience: configuration["Logging:Auth:audience"],
                claims: claims,
                expires: expiracao,
                signingCredentials: credenciais
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
