using AutoMapper;
using Microsoft.IdentityModel.Tokens;
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

        private readonly UsuarioRepository usuarioRepository;

        public UsuarioPerfilService(UsuarioPerfilRepository repository, TokenService tokenService,
            UsuarioRepository usuarioRepository) 
        {
            this.repository = repository;
            this.tokenService = tokenService;
            this.usuarioRepository = usuarioRepository;
        }

        public virtual async Task<UsuarioPerfilRespostaDTO> ObterPorUIDAsync(string usuarioUID,
            string projetoUID, string perfilUID)
        {
            var obj = await repository.ObterPorUIDAsync(usuarioUID, projetoUID, perfilUID);

            return obj == null ? 
                throw new ObjetoNaoEncontrado($"{usuarioUID} + ${projetoUID} + ${perfilUID}") 
                : ConverterParaDTORespostaAsync(obj);
        }

        public virtual async Task<List<UsuarioPerfilRespostaDTO>> ObterPorUIDUsuarioUIDAsync(string usuarioUID)
        {
            var usuario = usuarioRepository.ObterPorUIDAsync(usuarioUID);

            if (usuario == null)
            {
                throw new ObjetoNaoEncontrado(usuarioUID);
            }

            var objs = await repository.ObterTudoPorUsuarioUIDAsync(usuarioUID);
            var objsResposta = new List<UsuarioPerfilRespostaDTO>();

            objs.ForEach(o => objsResposta.Add(ConverterParaDTORespostaAsync(o)));

            return objsResposta;
        }

        public virtual async Task<List<UsuarioPerfilRespostaDTO>> ObterTudoAsync(
            int numeroPagina)
        {
            var objs = await repository.ObterTudoAsync(numeroPagina);
            var objsResposta = new List<UsuarioPerfilRespostaDTO>();

            objs.ForEach(o => objsResposta.Add(ConverterParaDTORespostaAsync(o)));

            return objsResposta;
        }

        public virtual async Task<UsuarioPerfilRespostaDTO> AdicionarAsync(
            UsuarioPerfilEnvioDTO obj, IEnumerable<Claim> claims)
        {
            var objClasse = ConverterParaClasse(obj);
            objClasse.UsuarioCriadorUID = tokenService.ObterUID(claims);

            await repository.AdicionarAsync(objClasse);

            var objAposSerCriado = await repository.ObterPorUIDAsync(obj.UsuarioUID, obj.ProjetoUID, 
                obj.PerfilUID);

            if (objAposSerCriado == null)
            {
                throw new Exception("Objeto atualizado não foi encontrado.");
            }

            return ConverterParaDTORespostaAsync(objAposSerCriado);
        }

        public virtual async Task<UsuarioPerfilRespostaDTO> EditarAsync(
            string usuarioUID, string projetoUID, string perfilUID,
            UsuarioPerfilEnvioDTO obj, IEnumerable<Claim> claims)
        {
            //Verifica se o objeto existe.
            var objClasse = ConverterParaClasse(obj);

            objClasse.UsuarioUID = usuarioUID;
            objClasse.ProjetoUID = projetoUID;
            objClasse.PerfilUID = perfilUID;

            if (!await ExistePorUIDAsync(usuarioUID, projetoUID, perfilUID))
            {
                throw new ObjetoNaoEncontrado($"{usuarioUID} + ${projetoUID} + ${perfilUID}");
            }

            //Edita o objeto.
            objClasse.AtualizadoPorUID = tokenService.ObterUID(claims);
            await repository.EditarAsync(objClasse);

            //Coloca como falso o perfil antigo.
            UsuarioPerfil perfilAtivadoAntigo = new();

            var outrosPerfis = await repository.ObterTudoPorUsuarioUIDAsync(objClasse.UsuarioUID);
            outrosPerfis.ForEach(o =>
            {
                //Se for um perfil diferente no mesmo projeto e ativado ou,
                //O mesmo perfil em um projeto diferente e ativado, coloca como falso.
                if (!o.PerfilUID.Equals(objClasse.PerfilUID) && o.Ativado 
                    || !o.ProjetoUID.Equals(objClasse.ProjetoUID) && o.Ativado)
                {
                    perfilAtivadoAntigo = o;
                    perfilAtivadoAntigo.Ativado = false;
                }
            });

            if (!perfilAtivadoAntigo.UsuarioUID.IsNullOrEmpty())
            {
                await repository.EditarAsync(perfilAtivadoAntigo);
            }

            //Obtém a versão mais recente do obj.
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
