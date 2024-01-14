using NexusAPI.Administracao.DTOs.Projeto;
using NexusAPI.Administracao.DTOs.UsuarioProjetoPerfil;
using NexusAPI.Administracao.Models;
using NexusAPI.Administracao.Repositories;
using NexusAPI.Compartilhado.EntidadesBase;
using NexusAPI.Compartilhado.Exceptions;
using NexusAPI.Compartilhado.Services;
using System.Security.Claims;

namespace NexusAPI.Administracao.Services
{
    public class UsuarioProjetoPerfilService
    {
        private readonly UsuarioProjetoPerfilRepository repository;

        private readonly TokenService tokenService;

        public UsuarioProjetoPerfilService(UsuarioProjetoPerfilRepository repository, 
            TokenService tokenService) 
        {
            this.repository = repository;
            this.tokenService = tokenService;
        }

        public virtual async Task<UsuarioProjetoPerfilRespostaDTO> ObterPorUIDAsync(string usuarioUID,
            string projetoUID, string perfilUID)
        {
            var obj = await repository.ObterPorUIDAsync(usuarioUID, projetoUID, perfilUID);

            return obj == null ? 
                throw new ObjetoNaoEncontrado($"{usuarioUID} + ${projetoUID} + ${perfilUID}") 
                : await ConverterParaDTORespostaAsync(obj);
        }

        public virtual async Task<List<UsuarioProjetoPerfilRespostaDTO>> ObterTudoAsync(
            int numeroPagina)
        {
            var objs = await repository.ObterTudoAsync(numeroPagina);
            var objsResposta = new List<UsuarioProjetoPerfilRespostaDTO>();

            objs.ForEach(async o => objsResposta.Add(await ConverterParaDTORespostaAsync(o)));

            return objsResposta;
        }

        public virtual async Task<UsuarioProjetoPerfilRespostaDTO> AdicionarAsync(
            UsuarioProjetoPerfilEnvioDTO obj, IEnumerable<Claim> claims)
        {
            var objClasse = ConverterParaClasse(obj);
            objClasse.UsuarioCriadorUID = tokenService.ObterUID(claims);

            return await ConverterParaDTORespostaAsync(await repository.AdicionarAsync(objClasse));
        }

        public virtual async Task<UsuarioProjetoPerfilRespostaDTO> EditarAsync(
            string usuarioUID, string projetoUID, string perfilUID,
            UsuarioProjetoPerfilEnvioDTO obj, IEnumerable<Claim> claims)
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

            return await ConverterParaDTORespostaAsync(objAposSerAtualizado);
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

        //public virtual async Task<string> ObterNomePorUIDAsync(string usuarioUID,
        //    string projetoUID, string perfilUID)
        //{
        //    var obj = await repository.ObterPorUIDAsync(usuarioUID, projetoUID, perfilUID);
        //    return obj == null ? 
        //        throw new ObjetoNaoEncontrado(UID) : 
        //        obj;
        //}

        public async Task<UsuarioProjetoPerfilRespostaDTO> ConverterParaDTORespostaAsync(
            UsuarioProjetoPerfil obj)
        {
            var resposta = new UsuarioProjetoPerfilRespostaDTO()
            {
                UsuarioUID = obj.UsuarioUID,
                ProjetoUID = obj.ProjetoUID,
                PerfilUID = obj.PerfilUID,
                Ativado = obj.Ativado,

                DataUltimaAtualizacao = obj.DataUltimaAtualizacao,
                AtualizadoPor = new NexusNomeObjeto()
                {
                    UID = obj.AtualizadoPorUID,
                    //Nome = obj.AtualizadoPorUID != null ?
                    //    await ObterNomePorUIDAsync(obj.AtualizadoPorUID) : null
                },

                UsuarioCriador = new NexusNomeObjeto()
                {
                    UID = obj.UsuarioCriadorUID,
                    //Nome = obj.UsuarioCriadorUID != null ?
                    //    await ObterNomePorUIDAsync(obj.UsuarioCriadorUID) : null
                },
                DataCriacao = obj.DataCriacao
            };

            return resposta;
        }

        public UsuarioProjetoPerfil ConverterParaClasse(UsuarioProjetoPerfilEnvioDTO obj)
        {
            var resposta = new UsuarioProjetoPerfil()
            {
                UsuarioUID = obj.UsuarioUID,
                ProjetoUID = obj.ProjetoUID,
                PerfilUID = obj.PerfilUID,
                Ativado = obj.Ativado
            };

            return resposta;
        }
    }
}
