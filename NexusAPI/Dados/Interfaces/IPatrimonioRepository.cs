using NexusAPI.Compartilhado.Data;
using NexusAPI.Compartilhado.EntidadesBase;
using NexusAPI.Dados.Models;

namespace NexusAPI.Dados.Interfaces
{
    public interface IPatrimonioRepository<T> where T : NexusObjeto
    {
        public Task<T?> ObterPorNumeroSerieAsync(string numeroSerie);
    }
}
