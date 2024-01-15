using AutoMapper;
using NexusAPI.Administracao.DTOs.Projeto;
using NexusAPI.Administracao.DTOs.UsuarioPerfil;
using NexusAPI.Administracao.Models;
using NexusAPI.Administracao.Repositories;
using NexusAPI.Compartilhado.EntidadesBase;
using NexusAPI.Compartilhado.Exceptions;
using NexusAPI.Compartilhado.Services;
using System.Security.Claims;

namespace NexusAPI.Administracao.Services
{
    public class UsuarioPerfilService
    {
        private readonly UsuarioPerfilRepository repository;

        private readonly TokenService tokenService;

        public UsuarioPerfilService(UsuarioPerfilRepository repository, 
            TokenService tokenService) 
        {
            this.repository = repository;
            this.tokenService = tokenService;
        }

        public virtual async Task<UsuarioPerfilRespostaDTO> ObterPorUIDAsync(string usuarioUID,
            string projetoUID, string perfilUID)
        {
            var obj = await repository.ObterPorUIDAsync(usuarioUID, projetoUID, perfilUID);

            return obj == null ? 
                throw new ObjetoNaoEncontrado($"{usuarioUID} + ${projetoUID} + ${perfilUID}") 
                : ConverterParaDTORespostaAsync(obj);
        }

        public virtual async Task<List<UsuarioPerfilRespostaDTO>> ObterTudoAsync(
            int numeroPagina)
        {
            var objs = await repository.ObterTudoAsync(numeroPagina);
            var objsResposta = new List<UsuarioPerfilRespostaDTO>();

            objs.ForEach(async o => objsResposta.Add(ConverterParaDTORespostaAsync(o)));

            return objsResposta;
        }

        public virtual async Task<UsuarioPerfilRespostaDTO> AdicionarAsync(
            UsuarioPerfilEnvioDTO obj, IEnumerable<Claim> claims)
        {
            var objClasse = ConverterParaClasse(obj);
            objClasse.UsuarioCriadorUID = tokenService.ObterUID(claims);

            return ConverterParaDTORespostaAsync(await repository.AdicionarAsync(objClasse));
        }

        public virtual async Task<UsuarioPerfilRespostaDTO> EditarAsync(
            string usuarioUID, string projetoUID, string perfilUID,
            UsuarioPerfilEnvioDTO obj, IEnumerable<Claim> claims)
        {
            var objClasse = ConverterParaClasse(obj);

            objClasse.UsuarioUID = usuarioUID;
            objClasse.ProjetoUID = projetoUID;
            objClasse.PerfilUID = perfilUID;

            if (!await ExistePorUIDAsync(usuarioUID, projetoUID, perfilUID))
            {
                throw new ObjetoNaoEncontrado($"{usuarioUID} + ${projetoUID} + ${perfilUID}");
            }

            objClasse.AtualizadoPorUID = tokenService.ObterUID(claims);

            await repository.EditarAsync(objClasse);

            var objAposSerAtualizado = await repository.ObterPorUIDAsync(usuarioUID, 
                projetoUID, perfilUID);

            if (objAposSerAtualizado == null)
            {
                throw new Exception("Objeto atualizado não foi encontrado.");
            }

            return ConverterParaDTORespostaAsync(objAposSerAtualizado);
        }

        public virtual async Task DeletarAsync(string usuarioUID,
            string projetoUID, string perfilUID, IEnumerable<Claim> claims)
        {
            var objClasse = await repository.ObterPorUIDAsync(usuarioUID, projetoUID, perfilUID);

            if (objClasse == null)
            {
                throw new ObjetoNaoEncontrado($"{usuarioUID} + ${projetoUID} + ${perfilUID}");
            }

            objClasse.FinalizadoPorUID = tokenService.ObterUID(claims);

            await repository.DeletarAsync(objClasse);
        }


        public virtual async Task<bool> ExistePorUIDAsync(string usuarioUID, 
            string projetoUID, string perfilUID)
        {
            var obj = await repository.ObterPorUIDAsync(usuarioUID, projetoUID, perfilUID);
            return obj != null;
        }

        public UsuarioPerfilRespostaDTO ConverterParaDTORespostaAsync(
            UsuarioPerfil obj)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UsuarioPerfil, UsuarioPerfilRespostaDTO>()
                    .ForMember(c => c.AtualizadoPor, opt => opt.Ignore())
                    .ForMember(c => c.UsuarioCriador, opt => opt.Ignore())
                    .ForMember(c => c.Usuario, opt => opt.Ignore())
                    .ForMember(c => c.Projeto, opt => opt.Ignore())
                    .ForMember(c => c.Perfil, opt => opt.Ignore());
            });
            var mapper = new Mapper(config);

            var resposta = mapper.Map<UsuarioPerfilRespostaDTO>(obj);

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

            resposta.Usuario = new NexusNomeObjeto()
            {
                UID = obj.Usuario?.UID,
                Nome = obj.Usuario?.Nome,
            };

            resposta.Projeto = new NexusNomeObjeto()
            {
                UID = obj.Projeto?.UID,
                Nome = obj.Projeto?.Nome,
            };

            resposta.Perfil = new NexusNomeObjeto()
            {
                UID = obj.Perfil?.UID,
                Nome = obj.Perfil?.Nome,
            };

            return resposta;
        }

        public UsuarioPerfil ConverterParaClasse(UsuarioPerfilEnvioDTO obj)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<UsuarioPerfilEnvioDTO, UsuarioPerfil>());
            var mapper = new Mapper(config);

            return mapper.Map<UsuarioPerfil>(obj);
        }
    }
}
