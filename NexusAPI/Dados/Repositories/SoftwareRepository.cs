using NexusAPI.Compartilhado.Data;
using NexusAPI.Compartilhado.EntidadesBase;
using NexusAPI.Dados.Models;

namespace NexusAPI.Dados.Repositories
{
    public class SoftwareRepository : BaseRepository<Software>
    {
        public SoftwareRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
