using Microsoft.EntityFrameworkCore;
using NexusAPI.Compartilhado.Data;
using NexusAPI.Compartilhado.EntidadesBase;
using NexusAPI.Compartilhado.Interfaces;
using NexusAPI.Dados.Models;

namespace NexusAPI.Dados.Repositories
{
    public class ManutencaoRepository : NexusRepository<Manutencao>
    {
        public ManutencaoRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public override async Task<Manutencao?> ObterPorUIDAsync(string UID)
        {
            return await dataContext.Set<Manutencao>()
                .Include(obj => obj.AtualizadoPor)
                .Include(obj => obj.UsuarioCriador)
                .Include(obj => obj.Componente)
                .FirstOrDefaultAsync(obj => obj.UID.Equals(UID) && obj.DataFinalizacao == null);
        }

        public async Task<List<Manutencao>> ObterTudoPorProjetoUIDAsync(int numeroPagina, 
            string projetoUID)
        {
            return await dataContext.Set<Manutencao>()
                .Include(obj => obj.AtualizadoPor)
                .Include(obj => obj.UsuarioCriador)
                .Include(obj => obj.Componente)
                .Where(obj => obj.DataFinalizacao == null && obj.ProjetoUID.Equals(projetoUID))
                .OrderBy(obj => obj.DataCriacao)
                .Skip((numeroPagina - 1) * Constantes.QUANTIDADE_ITEMS_PAGINA)
                .Take(Constantes.QUANTIDADE_ITEMS_PAGINA)
                .ToListAsync();
        }
    }
}
