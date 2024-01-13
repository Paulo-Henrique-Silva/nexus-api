using NexusAPI.Compartilhado.Exceptions;

namespace NexusAPI.Compartilhado.EntidadesBase
{
    /// <summary>
    /// Interface para implementar serviços de regras de negócio.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBaseService<T> where T : BaseObjeto
    {
        public Task<T> ObterPorIdAsync(string UID);

        public Task<List<T>> ObterTudoAsync();

        public Task<bool> ExistePorUID(string UID);

        public Task<T> Adicionar(T obj);

        public Task<T> Editar(T obj);

        public Task Deletar(T obj);
    }
}
