using NexusAPI.Administracao.Models;
using NexusAPI.Compartilhado;

namespace NexusAPI.Administracao.Repositories
{
    public class NotificacaoRepository : BaseRepository<Notificacao>
    {
        public NotificacaoRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
