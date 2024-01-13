using NexusAPI.Compartilhado;
using NexusAPI.Dados.Models;

namespace NexusAPI.Dados.Repositories
{
    public class LocalizacaoRepository : BaseRepository<Localizacao>
    {
        public LocalizacaoRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
