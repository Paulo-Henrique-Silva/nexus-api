using NexusAPI.Compartilhado.EntidadesBase;
using NexusAPI.Dados.Models;

namespace NexusAPI.Dados.Interfaces
{
    public interface IProjetoItemRepository<T> where T : NexusObjeto
    {
        public Task<List<T>> ObterTudoPorProjetoUIDAsync(int numeroPagina,
            string projetoUID);
    }
}
