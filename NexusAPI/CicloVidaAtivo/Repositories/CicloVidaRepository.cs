using NexusAPI.Compartilhado.Data;
using NexusAPI.Compartilhado.EntidadesBase;

namespace NexusAPI.CicloVidaAtivo.Repositories
{
    public class CicloVidaRepository : NexusRepository<Models.CicloVida>
    {
        public CicloVidaRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
