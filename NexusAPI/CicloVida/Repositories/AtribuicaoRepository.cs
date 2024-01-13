using NexusAPI.Administracao.Models;
using NexusAPI.CicloVida.Models;
using NexusAPI.Compartilhado.Data;
using NexusAPI.Compartilhado.EntidadesBase;

namespace NexusAPI.CicloVida.Repositories
{
    public class AtribuicaoRepository : BaseRepository<Atribuicao>
    {
        public AtribuicaoRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
