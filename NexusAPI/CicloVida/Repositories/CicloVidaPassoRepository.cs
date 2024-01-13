using NexusAPI.CicloVida.Models;
using NexusAPI.Compartilhado;

namespace NexusAPI.CicloVida.Repositories
{
    public class CicloVidaPassoRepository : BaseRepository<CicloVidaPasso>
    {
        public CicloVidaPassoRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
