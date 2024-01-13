using NexusAPI.Compartilhado;
using NexusAPI.Dados.Models;

namespace NexusAPI.Dados.Repositories
{
    public class ManutencaoRepository : BaseRepository<Manutencao>
    {
        public ManutencaoRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
