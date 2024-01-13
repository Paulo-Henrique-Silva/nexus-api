using NexusAPI.Administracao.Models;
using NexusAPI.Compartilhado.Data;
using NexusAPI.Compartilhado.EntidadesBase;

namespace NexusAPI.Administracao.Repositories
{
    public class ProjetoRepository : BaseRepository<Projeto>
    {
        public ProjetoRepository(DataContext dataContext) : base(dataContext)
        {

        }
    }
}
