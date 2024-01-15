using Microsoft.EntityFrameworkCore;
using NexusAPI.CicloVidaAtivo.Models;
using NexusAPI.Compartilhado.Data;
using NexusAPI.Compartilhado.EntidadesBase;
using NexusAPI.Compartilhado.Interfaces;

namespace NexusAPI.CicloVidaAtivo.Repositories
{
    public class CicloVidaPassoRepository : NexusRepository<CicloVidaPasso>
    {
        public CicloVidaPassoRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public override async Task<CicloVidaPasso?> ObterPorUIDAsync(string UID)
        {
            return await dataContext.Set<CicloVidaPasso>()
                .Include(obj => obj.AtualizadoPor)
                .Include(obj => obj.UsuarioCriador)
                .Include(obj => obj.CicloVida)
                .Include(obj => obj.PassoFalha)
                .Include(obj => obj.PassoSucesso)
                .FirstOrDefaultAsync(obj => obj.UID.Equals(UID) && obj.DataFinalizacao == null);
        }

        public override async Task<List<CicloVidaPasso>> ObterTudoAsync(int numeroPagina)
        {
            return await dataContext.Set<CicloVidaPasso>()
                .Include(obj => obj.AtualizadoPor)
                .Include(obj => obj.UsuarioCriador)
                .Include(obj => obj.CicloVida)
                .Include(obj => obj.PassoFalha)
                .Include(obj => obj.PassoSucesso)
                .Where(obj => obj.DataFinalizacao == null)
                .OrderBy(obj => obj.DataCriacao)
                .Skip((numeroPagina - 1) * Constantes.QUANTIDADE_ITEMS_PAGINA)
                .Take(Constantes.QUANTIDADE_ITEMS_PAGINA)
                .ToListAsync();
        }
    }
}
