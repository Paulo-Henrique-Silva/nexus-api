using AutoMapper;
using NexusAPI.Administracao.DTOs.Usuario;
using NexusAPI.Administracao.Exceptions;
using NexusAPI.Administracao.Models;
using NexusAPI.Administracao.Repositories;
using NexusAPI.Compartilhado.EntidadesBase.DTOs;
using NexusAPI.Compartilhado.EntidadesBase.MVC;
using NexusAPI.Compartilhado.EntidadesBase.Objetos;
using NexusAPI.Compartilhado.Exceptions;
using NexusAPI.Compartilhado.Services;
using System.Security.Claims;

namespace NexusAPI.Administracao.Services
{
    public class UsuarioService : NexusService<UsuarioEnvioDTO, UsuarioRespostaDTO, Usuario>
    {
        private readonly UsuarioRepository usuarioRepository;

        public UsuarioService(UsuarioRepository repository, TokenService tokenService) 
        : base(repository, tokenService) 
        {
            usuarioRepository = repository;
        }

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

            resposta.AtualizadoPor = new NexusReferenciaObjeto()
            {
                UID = obj.AtualizadoPor?.UID,
                Nome = obj.AtualizadoPor?.Nome
            };

            resposta.UsuarioCriador = new NexusReferenciaObjeto()
            {
                UID = obj.UsuarioCriador?.UID,
                Nome = obj.UsuarioCriador?.Nome
            };

            return resposta;
        }

        /// <summary>
        /// Obtém os registros por nome e quantidade de itens.
        /// </summary>
        /// <param name="numeroPagina"></param>
        /// <param name="nome"></param>
        /// <returns></returns>
        public async Task<NexusListaRespostaDTO<UsuarioRespostaDTO>> ObterCoordenadoresPorNomeAsync(int numeroPagina, string nome, string projetoUID)
        {
            var objs = await usuarioRepository.ObterCoordenadoresPorNomeAsync(numeroPagina, nome, projetoUID);
            var objsResposta = new List<UsuarioRespostaDTO>();

            objs.ForEach(o => objsResposta.Add(ConverterParaDTOResposta(o)));

            var resposta = new NexusListaRespostaDTO<UsuarioRespostaDTO>()
            {
                TotalItens = await usuarioRepository.ObterCountPorNomeAsync(nome),
                Itens = objsResposta
            };

            return resposta;
        }

        public async override Task<UsuarioRespostaDTO> AdicionarAsync(UsuarioEnvioDTO usuarioDTO, IEnumerable<Claim> claims)
        {
            //Verifica se o usuário já existe.
            var usuarioBD = await usuarioRepository.ObterPorNomeAcessoAsync(usuarioDTO.NomeAcesso);

            if (usuarioBD != null)
            {
                throw new NomeAcessoJaCadastrado();
            }

            //Converte para model para cadastrar.
            var usuario = ConverterParaClasse(usuarioDTO);

            usuario.UID = Guid.NewGuid().ToString();
            usuario.Senha = BCrypt.Net.BCrypt.HashPassword(usuario.Senha);
            usuario.UsuarioCriadorUID = tokenService.ObterUsuarioUID(claims);

            await usuarioRepository.AdicionarAsync(usuario);

            //Obtém o usuário após ser cadastrado para ter as informações completas.
            var usuarioAposSerCadastrado = await usuarioRepository.ObterPorUIDAsync(usuario.UID);

            if (usuarioAposSerCadastrado == null)
            {
                throw new Exception("Objeto atualizado não foi encontrado.");
            }

            //gera token do usuário.
            var dtoResposta = ConverterParaDTOResposta(usuarioAposSerCadastrado);
            dtoResposta.Token = tokenService.GerarToken(dtoResposta.UID, dtoResposta.NomeAcesso);

            return dtoResposta;
        }

        public override async Task<UsuarioRespostaDTO> EditarAsync(string UID, UsuarioEnvioDTO obj, IEnumerable<Claim> claims)
        {
            //Verifica se o usuário existe.
            var usuario = ConverterParaClasse(obj);
            usuario.UID = UID;

            if (!await ExistePorUIDAsync(usuario.UID))
            {
                throw new ObjetoNaoEncontrado(usuario.UID);
            }

            //Converte pra model e atualiza no BD.
            usuario.AtualizadoPorUID = tokenService.ObterUsuarioUID(claims);
            usuario.Senha = BCrypt.Net.BCrypt.HashPassword(usuario.Senha);

            await usuarioRepository.EditarAsync(usuario);

            //Obtém o usuário para ter as informações completas.
            var usuarioAposSerAtualizado = await usuarioRepository.ObterPorUIDAsync(UID);

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
            var usuario = await usuarioRepository.ObterPorNomeAcessoAsync(usuarioEnvio.NomeAcesso);

            //Se o usuario não existe ou a senha for incorreta.
            if (usuario == null || !BCrypt.Net.BCrypt.Verify(usuarioEnvio.Senha, usuario.Senha))
            {
                throw new CredenciaisIncorretas();
            }

            UsuarioRespostaDTO resposta = ConverterParaDTOResposta(usuario);
            resposta.Token = tokenService.GerarToken(usuario.UID, usuario.NomeAcesso);

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
