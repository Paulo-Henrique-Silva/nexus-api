using AutoMapper;
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
    public class UsuarioService : NexusService<UsuarioEnvioDTO, UsuarioRespostaDTO, Usuario>
    {
        public UsuarioService(UsuarioRepository repository, TokenService tokenService) 
        : base(repository, tokenService) { }

        public override UsuarioRespostaDTO ConverterParaDTOResposta(Usuario obj)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Usuario, UsuarioRespostaDTO>()
                    .ForMember(c => c.AtualizadoPor, opt => opt.Ignore())
                    .ForMember(c => c.UsuarioCriador, opt => opt.Ignore());
            });
            var mapper = new Mapper(config);

            var resposta = mapper.Map<UsuarioRespostaDTO>(obj);

            resposta.AtualizadoPor = new NexusNomeObjeto()
            {
                UID = obj.AtualizadoPor?.UID,
                Nome = obj.AtualizadoPor?.Nome
            };

            resposta.UsuarioCriador = new NexusNomeObjeto()
            {
                UID = obj.UsuarioCriador?.UID,
                Nome = obj.UsuarioCriador?.Nome
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

            var dtoResposta = ConverterParaDTOResposta
            (
                await repository.AdicionarAsync(usuario)
            );
            dtoResposta.Token = new TokenDTO() 
            { 
                Token = tokenService.GerarToken(dtoResposta.UID, dtoResposta.NomeAcesso) 
            };

            return dtoResposta;
        }

        public override async Task<UsuarioRespostaDTO> EditarAsync(string UID, UsuarioEnvioDTO obj, 
            IEnumerable<Claim> claims)
        {
            var usuario = ConverterParaClasse(obj);
            usuario.UID = UID;

            if (!await ExistePorUIDAsync(usuario.UID))
            {
                throw new ObjetoNaoEncontrado(usuario.UID);
            }

            usuario.AtualizadoPorUID = tokenService.ObterUID(claims);
            usuario.Senha = BCrypt.Net.BCrypt.HashPassword(usuario.Senha);

            await repository.EditarAsync(usuario);

            var usuarioAposSerAtualizado = await repository.ObterPorUIDAsync(UID);

            if (usuarioAposSerAtualizado == null)
            {
                throw new Exception("Objeto atualizado não foi encontrado.");
            }

            return ConverterParaDTOResposta(usuarioAposSerAtualizado);
        }

        /// <summary>
        /// Autentica o usuário e retorna o token JWT.
        /// </summary>
        /// <param name="usuarioEnvio"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        /// <exception cref="CredenciaisIncorretas"></exception>
        public async Task<UsuarioRespostaDTO> AutenticarUsuario(UsuarioEnvioDTO usuarioEnvio)
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

            UsuarioRespostaDTO resposta = ConverterParaDTOResposta(usuario);
            resposta.Token = new TokenDTO() { Token = tokenService.GerarToken(usuario.UID, usuario.NomeAcesso) };

            return resposta;
        }

        /// <summary>
        /// Verifica a senha enviada condiz com
        /// </summary>
        /// <param name="usuarioEnvio"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        /// <exception cref="CredenciaisIncorretas"></exception>
        public async Task<SenhaCorretaDTO> VerificarSenha(string UID, UsuarioEnvioDTO usuarioEnvio)
        {
            var usuarioRepository = repository as UsuarioRepository;

            //Converte repository para UsuarioRepository para utilizar metodo especifico.
            if (usuarioRepository == null)
            {
                throw new Exception("Instância incorreta em 'repository'.");
            }

            var usuario = await usuarioRepository.ObterPorUIDAsync(UID);

            //Se o usuario não existe ou a senha for incorreta.
            if (usuario == null)
            {
                throw new ObjetoNaoEncontrado(UID);
            }

            bool senhaCorreta = BCrypt.Net.BCrypt.Verify(usuarioEnvio.Senha, usuario.Senha);

            return new SenhaCorretaDTO() { SenhaCorreta = senhaCorreta };
        }
    }
}
