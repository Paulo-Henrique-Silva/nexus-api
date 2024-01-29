using NexusAPI.Compartilhado.EntidadesBase;
using NexusAPI.Compartilhado.EntidadesBase.DTOs;

namespace NexusAPI.Dados.Interfaces
{
    public interface IProjetoItemService<U> where U : NexusRespostaDTO
    {
        public Task<List<U>> ObterTudoPorProjetoUIDAsync(int numeroPagina, string projetoUID);
    }
}
