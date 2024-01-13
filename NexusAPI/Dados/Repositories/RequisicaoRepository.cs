using NexusAPI.Compartilhado;
using NexusAPI.Dados.Models;

namespace NexusAPI.Dados.Repositories
{
    public class RequisicaoRepository : BaseRepository<Requisicao>
    {
        public RequisicaoRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
