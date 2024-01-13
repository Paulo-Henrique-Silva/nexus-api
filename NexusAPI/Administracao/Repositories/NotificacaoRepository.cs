using NexusAPI.Administracao.Models;
using NexusAPI.Compartilhado.Data;
using NexusAPI.Compartilhado.EntidadesBase;

namespace NexusAPI.Administracao.Repositories
{
    public class NotificacaoRepository : BaseRepository<Notificacao>
    {
        public NotificacaoRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
