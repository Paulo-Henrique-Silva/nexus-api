using NexusAPI.Administracao.Models;
using NexusAPI.Compartilhado;

namespace NexusAPI.Administracao.Repositories
{
    public class PerfilRepository : BaseRepository<Perfil>
    {
        public PerfilRepository(DataContext dataContext) : base(dataContext)
        {
            
        }
    }
}
