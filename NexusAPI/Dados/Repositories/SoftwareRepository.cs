using Microsoft.EntityFrameworkCore;
using NexusAPI.Compartilhado.Data;
using NexusAPI.Compartilhado.EntidadesBase;
using NexusAPI.Compartilhado.Interfaces;
using NexusAPI.Dados.Models;

namespace NexusAPI.Dados.Repositories
{
    public class SoftwareRepository : NexusRepository<Software>
    {
        public SoftwareRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public override async Task<Software?> ObterPorUIDAsync(string UID)
        {
            return await dataContext.Set<Software>()
                .Include(obj => obj.AtualizadoPor)
                .Include(obj => obj.UsuarioCriador)
                .Include(obj => obj.Componente)
                .FirstOrDefaultAsync(obj => obj.UID.Equals(UID) && obj.DataFinalizacao == null);
        }

        public override async Task<List<Software>> ObterTudoAsync(int numeroPagina)
        {
            return await dataContext.Set<Software>()
                .Include(obj => obj.AtualizadoPor)
                .Include(obj => obj.UsuarioCriador)
                .Include(obj => obj.Componente)
                .Where(obj => obj.DataFinalizacao == null)
                .OrderBy(obj => obj.DataCriacao)
                .Skip((numeroPagina - 1) * Constantes.QUANTIDADE_ITEMS_PAGINA)
                .Take(Constantes.QUANTIDADE_ITEMS_PAGINA)
                .ToListAsync();
        }
    }
}
