using Microsoft.IdentityModel.Tokens;
using NexusAPI.Administracao.DTOs.Usuario;
using NexusAPI.Administracao.Exceptions;
using NexusAPI.Administracao.Models;
using NexusAPI.Administracao.Repositories;
using NexusAPI.Compartilhado.EntidadesBase;
using NexusAPI.Compartilhado.Exceptions;
using NexusAPI.Compartilhado.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NexusAPI.Administracao.Services
{
    public class UsuariosService : NexusService<UsuarioEnvioDTO, UsuarioRespostaDTO, Usuario>
    {
        public UsuariosService(UsuarioRepository repository, TokenService tokenService) 
        : base(repository, tokenService) { }

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

        public override UsuarioRespostaDTO ConverterParaDTORespostaAsync(Usuario obj)
        {
            var resposta = new UsuarioRespostaDTO()
            {
                NomeAcesso = obj.NomeAcesso,
                UID = obj.UID,
                Nome = obj.Nome,
                Descricao = obj.Descricao,

                DataUltimaAtualizacao = obj.DataUltimaAtualizacao,
                AtualizadoPor = new NexusNomeObjeto()
                {
                    UID = obj.AtualizadoPor?.UID,
                    Nome = obj.AtualizadoPor?.Nome
                },

                DataCriacao = obj.DataCriacao,
                UsuarioCriador = new NexusNomeObjeto()
                {
                    UID = obj.UsuarioCriador?.UID,
                    Nome = obj.UsuarioCriador?.Nome
                }
            };

            return resposta;
        }

        public async override Task<UsuarioRespostaDTO> AdicionarAsync(UsuarioEnvioDTO usuarioDTO, 
            IEnumerable<Claim> claims)
        {
            var usuarioRepository = repository as UsuarioRepository;

            //Converte repository para UsuarioRepository para utilizar método especifico.
            if (usuarioRepository == null)
            {
                throw new Exception("Instância incorreta em 'repository'.");
            }

            var usuarioBD = await usuarioRepository
                .ObterPorNomeAcessoAsync(usuarioDTO.NomeAcesso);

            if (usuarioBD != null)
            {
                throw new NomeAcessoJaCadastrado();
            }

            var usuario = ConverterParaClasse(usuarioDTO);

            usuario.UID = Guid.NewGuid().ToString();
            usuario.Senha = BCrypt.Net.BCrypt.HashPassword(usuario.Senha);
            usuario.UsuarioCriadorUID = tokenService.ObterUID(claims);

            var dtoResposta = ConverterParaDTORespostaAsync
            (
                await repository.AdicionarAsync(usuario)
            );
            dtoResposta.Token = new TokenDTO() 
            { 
                Token = tokenService.GerarToken(dtoResposta.UID, dtoResposta.NomeAcesso) 
            };

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

            var usuario = await usuarioRepository
                .ObterPorNomeAcessoAsync(usuarioEnvio.NomeAcesso);

            //Se o usuario não existe ou a senha for incorreta.
            if (usuario == null || !BCrypt.Net.BCrypt.Verify(usuarioEnvio.Senha, usuario.Senha))
            {
                throw new CredenciaisIncorretas();
            }

            return new TokenDTO() 
            { 
                Token = tokenService.GerarToken(usuario.UID, usuario.NomeAcesso) 
            };
        }
    }
}
