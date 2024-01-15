using NexusAPI.CicloVidaAtivo.Models;
using NexusAPI.Compartilhado.Data;
using NexusAPI.Compartilhado.EntidadesBase;

namespace NexusAPI.CicloVidaAtivo.Repositories
{
    public class CicloVidaPassoRepository : NexusRepository<CicloVidaPasso>
    {
        public CicloVidaPassoRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
