using NexusAPI.Compartilhado.Data;
using NexusAPI.Compartilhado.EntidadesBase;
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
