using NexusAPI.Administracao.Models;
using NexusAPI.CicloVida.Models;
using NexusAPI.Compartilhado;

namespace NexusAPI.CicloVida.Repositories
{
    public class AtribuicaoRepository : BaseRepository<Atribuicao>
    {
        public AtribuicaoRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
