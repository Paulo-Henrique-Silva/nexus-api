using NexusAPI.Compartilhado.Data;
using NexusAPI.Compartilhado.EntidadesBase;
using NexusAPI.Dados.Models;

namespace NexusAPI.Dados.Repositories
{
    public class RequisicaoRepository : NexusRepository<Requisicao>
    {
        public RequisicaoRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
