using Microsoft.EntityFrameworkCore;
using NexusAPI.Compartilhado.Data;
using NexusAPI.Compartilhado.EntidadesBase;
using NexusAPI.Compartilhado.Interfaces;
using NexusAPI.Dados.Models;

namespace NexusAPI.Dados.Repositories
{
    public class RequisicaoRepository : NexusRepository<Requisicao>
    {
        public RequisicaoRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public override async Task<Requisicao?> ObterPorUIDAsync(string UID)
        {
            return await dataContext.Set<Requisicao>()
                .Include(obj => obj.AtualizadoPor)
                .Include(obj => obj.UsuarioCriador)
                .Include(obj => obj.Coordenador)
                .FirstOrDefaultAsync(obj => obj.UID.Equals(UID) && obj.DataFinalizacao == null);
        }

        public async Task<List<Requisicao>> ObterTudoPorProjetoUIDAsync(int numeroPagina, 
            string projetoUID)
        {
            return await dataContext.Set<Requisicao>()
                .Include(obj => obj.AtualizadoPor)
                .Include(obj => obj.UsuarioCriador)
                .Include(obj => obj.Coordenador)
                .Where(obj => obj.DataFinalizacao == null && obj.ProjetoUID.Equals(projetoUID))
                .OrderByDescending(obj => obj.DataCriacao)
                .Skip((numeroPagina - 1) * Constantes.QUANTIDADE_ITEMS_PAGINA)
                .Take(Constantes.QUANTIDADE_ITEMS_PAGINA)
                .ToListAsync();
        }
    }
}
