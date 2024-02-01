using NexusAPI.Compartilhado.EntidadesBase;
using NexusAPI.Dados.Models;

namespace NexusAPI.Dados.Interfaces
{
    public interface IProjetoItemRepository<T> where T : NexusObjeto
    {
        /// <summary>
        /// Obtém todos os itens não finalizados, pelo projeto especificaodo.
        /// </summary>
        /// <param name="numeroPagina"></param>
        /// <param name="projetoUID"></param>
        /// <returns></returns>
        public Task<List<T>> ObterTudoPorProjetoUIDAsync(int numeroPagina,
            string projetoUID);

        /// <summary>
        /// Obtém a quantidade de itens não finalizados, por projeto.
        /// </summary>
        /// <param name="projetoUID"></param>
        /// <returns></returns>
        public Task<int> ObterCountPorProjetoUIDAsync(string projetoUID);

        /// <summary>
        /// Obtém todos os itens não finalizados, pelo projeto e nome.
        /// </summary>
        /// <param name="numeroPagina"></param>
        /// <param name="projetoUID"></param>
        /// <param name="nome"></param>
        /// <returns></returns>
        public Task<List<T>> ObterTudoPorProjetoENomeAsync(int numeroPagina,
            string projetoUID, string nome);

        /// <summary>
        /// Obtém a quantidade de itens não finalizados, por projeto e nome.
        /// </summary>
        /// <param name="projetoUID"></param>
        /// <param name="nome"></param>
        /// <returns></returns>
        public Task<int> ObterCountPorProjetoENomeAsync(string projetoUID, string nome);
    }
}
