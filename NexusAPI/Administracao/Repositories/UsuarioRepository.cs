using NexusAPI.Administracao.Models;
using NexusAPI.Compartilhado.Data;
using NexusAPI.Compartilhado.EntidadesBase;

namespace NexusAPI.Administracao.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>
    {
        public UsuarioRepository(DataContext dataContext) : base(dataContext)
        {

        }
    }
}
