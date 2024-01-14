using Microsoft.EntityFrameworkCore;
using NexusAPI.Administracao.Models;
using NexusAPI.Administracao.Repositories;
using NexusAPI.Administracao.Services;
using NexusAPI.Compartilhado.Exceptions;
using NexusAPI.Compartilhado.Services;
using System.Security.Claims;

namespace NexusAPI.Compartilhado.EntidadesBase
{
    /// <summary>
    /// Interface para implementar serviços de regras de negócio.
    /// </summary>
    /// <typeparam name="T">DTO de Envio</typeparam>
    /// <typeparam name="U">DTO de resposta</typeparam>
    /// <typeparam name="O">Classe base</typeparam>
    public abstract class NexusService<T, U, O> where O : NexusObjeto
    {
        protected readonly NexusRepository<O> repository;

        protected readonly TokenService tokenService;

        protected readonly UsuariosService? usuarioService;

        public NexusService(NexusRepository<O> repository, TokenService tokenService, 
            UsuariosService? usuarioService)
        {
            this.repository = repository;
            this.tokenService = tokenService;
            this.usuarioService = usuarioService;
        }

        public virtual async Task<U> ObterPorUIDAsync(string UID)
        {
            var obj = await repository.ObterPorUIDAsync(UID);
            return obj == null ? throw new ObjetoNaoEncontrado(UID) : await ConverterParaDTORespostaAsync(obj);
        }

        public virtual async Task<List<U>> ObterTudoAsync(int numeroPagina)
        {
            var objs = await repository.ObterTudoAsync(numeroPagina);
            var objsResposta = new List<U>();
                
            objs.ForEach(async o => objsResposta.Add(await ConverterParaDTORespostaAsync(o)));

            return objsResposta;
        }

        public virtual async Task<U> AdicionarAsync(T obj, IEnumerable<Claim> claims)
        {
            var objClasse = ConverterParaClasse(obj);
            objClasse.UID = Guid.NewGuid().ToString();
            objClasse.UsuarioCriadorUID = tokenService.ObterUID(claims);

            return await ConverterParaDTORespostaAsync(await repository.AdicionarAsync(objClasse));
        }

        public virtual async Task<U> EditarAsync(string UID, T obj, IEnumerable<Claim> claims)
        {
            var objClasse = ConverterParaClasse(obj);
            objClasse.UID = UID;

            if (!await ExistePorUIDAsync(objClasse.UID))
            {
                throw new ObjetoNaoEncontrado(objClasse.UID);
            }

            objClasse.AtualizadoPorUID = tokenService.ObterUID(claims);

            await repository.EditarAsync(objClasse);

            var objAposSerAtualizado = await repository.ObterPorUIDAsync(UID);
            
            if (objAposSerAtualizado == null)
            {
                throw new Exception("Objeto atualizado não foi encontrado.");
            }

            return await ConverterParaDTORespostaAsync(objAposSerAtualizado);
        }

        public virtual async Task DeletarAsync(string UID, IEnumerable<Claim> claims)
        {
            var objClasse = await repository.ObterPorUIDAsync(UID);

            if (objClasse == null)
            {
                throw new ObjetoNaoEncontrado(UID);
            }

            objClasse.FinalizadoPorUID = tokenService.ObterUID(claims);

            await repository.DeletarAsync(objClasse);
        }


        public virtual async Task<bool> ExistePorUIDAsync(string UID)
        {
            var obj = await repository.ObterPorUIDAsync(UID);
            return obj != null;
        }

        public abstract Task<U> ConverterParaDTORespostaAsync(O obj);

        public abstract O ConverterParaClasse(T obj);
    }
}
