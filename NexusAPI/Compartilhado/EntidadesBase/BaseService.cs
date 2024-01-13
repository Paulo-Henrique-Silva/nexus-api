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
        private readonly BaseRepository<O> repository;

        public BaseService(BaseRepository<O> repository)
        {
            this.repository = repository;
        }

        public virtual async Task<U> ObterPorIdAsync(string UID)
        {
            var obj = await repository.ObterPorIdAsync(UID);
            return obj == null ? throw new ObjetoNaoEncontrado(UID) : await ConverterParaDTOResposta(obj);
        }

        public abstract Task<List<U>> ObterTudoAsync();

        public virtual async Task<U> Adicionar(T obj)
        {
            var objRetornado = await repository.AdicionarAsync(await ConverterParaClasse(obj));
            objRetornado.UsuarioCriadorUID = "";
            return await ConverterParaDTOResposta(objRetornado);
        }

        public virtual async Task<U> Editar(T obj)
        {
            var objRetornado = await repository.EditarAsync(await ConverterParaClasse(obj));
            objRetornado.AtualizadoPorUID = "";
            return await ConverterParaDTOResposta(objRetornado);
        }

        public virtual async Task Deletar(T obj)
        {
            var objRetornado = await ConverterParaClasse(obj);
            objRetornado.FinalizadoPorUID = "";
            await repository.DeletarAsync(await ConverterParaClasse(obj));
        }

        public abstract Task<U> ConverterParaDTOResposta(O obj);

        public abstract Task<O> ConverterParaClasse(T obj);

        public virtual async Task<bool> ExistePorUID(string UID)
        {
            var obj = await repository.ObterPorIdAsync(UID);
            return obj != null;
        }

        public virtual async Task<string> ObterNomePorUID(string UID)
        {
            var obj = await repository.ObterPorIdAsync(UID);
            return obj == null ? throw new ObjetoNaoEncontrado(UID) : obj.Nome;
        }
    }
}
