﻿using Microsoft.EntityFrameworkCore;
using NexusAPI.Administracao.Repositories;
using NexusAPI.Compartilhado.Exceptions;

namespace NexusAPI.Compartilhado.EntidadesBase
{
    /// <summary>
    /// Interface para implementar serviços de regras de negócio.
    /// </summary>
    /// <typeparam name="T">DTO de Envio</typeparam>
    /// <typeparam name="U">DTO de resposta</typeparam>
    /// <typeparam name="O">Classe base</typeparam>
    public abstract class BaseService<T, U, O> where O : BaseObjeto
    {
        protected readonly BaseRepository<O> repository;

        public BaseService(BaseRepository<O> repository)
        {
            this.repository = repository;
        }

        public virtual async Task<U> ObterPorIdAsync(string UID)
        {
            var obj = await repository.ObterPorIdAsync(UID);
            return obj == null ? throw new ObjetoNaoEncontrado(UID) : await ConverterParaDTORespostaAsync(obj);
        }

        public virtual async Task<List<U>> ObterTudoAsync(int numeroPagina)
        {
            var objs = await repository.ObterTudoAsync(numeroPagina);
            var objsResposta = new List<U>();
                
            objs.ForEach(async o => objsResposta.Add(await ConverterParaDTORespostaAsync(o)));

            return objsResposta;
        }

        public virtual async Task<U> AdicionarAsync(T obj)
        {
            var objClasse = ConverterParaClasse(obj);
            objClasse.UID = Guid.NewGuid().ToString();
            objClasse.UsuarioCriadorUID = null;

            return await ConverterParaDTORespostaAsync(await repository.AdicionarAsync(objClasse));
        }

        public virtual async Task<U> EditarAsync(T obj)
        {
            var objClasse = ConverterParaClasse(obj);
            objClasse.AtualizadoPorUID = null;

            return await ConverterParaDTORespostaAsync(await repository.EditarAsync(objClasse));
        }

        public virtual async Task DeletarAsync(T obj)
        {
            var objClasse = ConverterParaClasse(obj);
            objClasse.FinalizadoPorUID = null;

            await repository.DeletarAsync(objClasse);
        }


        public virtual async Task<bool> ExistePorUIDAsync(string UID)
        {
            var obj = await repository.ObterPorIdAsync(UID);
            return obj != null;
        }

        public virtual async Task<string> ObterNomePorUIDAsync(string UID)
        {
            var obj = await repository.ObterPorIdAsync(UID);
            return obj == null ? throw new ObjetoNaoEncontrado(UID) : obj.Nome;
        }

        public abstract Task<U> ConverterParaDTORespostaAsync(O obj);

        public abstract O ConverterParaClasse(T obj);
    }
}
