using NexusAPI.CicloVida.Models;
using NexusAPI.Compartilhado.Data;
using NexusAPI.Compartilhado.EntidadesBase;
using NexusAPI.Dados.Models;

namespace NexusAPI.Dados.Repositories
{
    public class ComponenteRepository : BaseRepository<Componente>
    {
        public ComponenteRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
