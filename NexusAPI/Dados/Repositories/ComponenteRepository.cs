using NexusAPI.CicloVida.Models;
using NexusAPI.Compartilhado;
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
