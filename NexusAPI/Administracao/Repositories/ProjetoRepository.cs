using NexusAPI.Administracao.Models;
using NexusAPI.Compartilhado;

namespace NexusAPI.Administracao.Repositories
{
    public class ProjetoRepository : BaseRepository<Projeto>
    {
        public ProjetoRepository(DataContext dataContext) : base(dataContext)
        {

        }
    }
}
