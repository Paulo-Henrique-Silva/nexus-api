using NexusAPI.Compartilhado.Data;
using NexusAPI.Compartilhado.EntidadesBase;

namespace NexusAPI.CicloVida.Repositories
{
    public class CicloVidaRepository : BaseRepository<Models.CicloVida>
    {
        public CicloVidaRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
