using NexusAPI.Compartilhado.Exceptions;

namespace NexusAPI.Compartilhado.EntidadesBase
{
    /// <summary>
    /// Interface para implementar serviços de regras de negócio.
    /// </summary>
    /// <typeparam name="T">DTO de Envio</typeparam>
    /// <typeparam name="U">DTO de resposta</typeparam>
    public interface IBaseService<T, U>
    {
        public Task<U> ObterPorIdAsync(string UID);

        public Task<List<U>> ObterTudoAsync();

        public Task<bool> ExistePorUID(string UID);

        public Task<U> Adicionar(T obj);

        public Task<U> Editar(T obj);

        public Task Deletar(T obj);
    }
}
