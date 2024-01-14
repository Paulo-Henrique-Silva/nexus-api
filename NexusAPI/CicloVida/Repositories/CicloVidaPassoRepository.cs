using NexusAPI.CicloVida.Models;
using NexusAPI.Compartilhado.Data;
using NexusAPI.Compartilhado.EntidadesBase;

namespace NexusAPI.CicloVida.Repositories
{
    public class CicloVidaPassoRepository : NexusRepository<CicloVidaPasso>
    {
        public CicloVidaPassoRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
