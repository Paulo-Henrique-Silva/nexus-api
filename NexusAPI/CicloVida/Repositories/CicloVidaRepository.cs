using NexusAPI.Compartilhado;

namespace NexusAPI.CicloVida.Repositories
{
    public class CicloVidaRepository : BaseRepository<Models.CicloVida>
    {
        public CicloVidaRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
