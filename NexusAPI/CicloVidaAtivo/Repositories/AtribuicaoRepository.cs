using NexusAPI.Administracao.Models;
using NexusAPI.CicloVidaAtivo.Models;
using NexusAPI.Compartilhado.Data;
using NexusAPI.Compartilhado.EntidadesBase;

namespace NexusAPI.CicloVidaAtivo.Repositories
{
    public class AtribuicaoRepository : NexusRepository<Atribuicao>
    {
        public AtribuicaoRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
