using NexusAPI.CicloVidaAtivo.Models;
using NexusAPI.Compartilhado.Data;
using NexusAPI.Compartilhado.EntidadesBase.MVC;

namespace NexusAPI.CicloVidaAtivo.Repositories
{
    public class CicloVidaRepository : NexusRepository<CicloVida>
    {
        public CicloVidaRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
