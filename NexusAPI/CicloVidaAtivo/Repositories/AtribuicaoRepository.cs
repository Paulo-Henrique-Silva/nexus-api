using Microsoft.EntityFrameworkCore;
using NexusAPI.Administracao.Models;
using NexusAPI.CicloVidaAtivo.Models;
using NexusAPI.Compartilhado.Data;
using NexusAPI.Compartilhado.EntidadesBase;
using NexusAPI.Compartilhado.Interfaces;

namespace NexusAPI.CicloVidaAtivo.Repositories
{
    public class AtribuicaoRepository : NexusRepository<Atribuicao>
    {
        public AtribuicaoRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public override async Task<Atribuicao?> ObterPorUIDAsync(string UID)
        {
            return await dataContext.Set<Atribuicao>()
                .Include(obj => obj.AtualizadoPor)
                .Include(obj => obj.UsuarioCriador)
                .Include(obj => obj.Usuario)
                .FirstOrDefaultAsync(obj => obj.UID.Equals(UID) && obj.DataFinalizacao == null);
        }

        public override async Task<List<Atribuicao>> ObterTudoUIDAsync(int numeroPagina)
        {
            return await dataContext.Set<Atribuicao>()
                .Include(obj => obj.AtualizadoPor)
                .Include(obj => obj.UsuarioCriador)
                .Include(obj => obj.Usuario)
                .Where(obj => obj.DataFinalizacao == null)
                .OrderBy(obj => obj.DataCriacao)
                .Skip((numeroPagina - 1) * Constantes.QUANTIDADE_ITEMS_PAGINA)
                .Take(Constantes.QUANTIDADE_ITEMS_PAGINA)
                .ToListAsync();
        }

        public async Task<List<Atribuicao>> ObterTudoPorUsuarioUIDAsync(int numeroPagina,
            string usuarioUID)
        {
            return await dataContext.Set<Atribuicao>()
                .Include(obj => obj.AtualizadoPor)
                .Include(obj => obj.UsuarioCriador)
                .Include(obj => obj.Usuario)
                .Where(obj => obj.DataFinalizacao == null && obj.UsuarioUID.Equals(usuarioUID))
                .OrderBy(obj => obj.DataCriacao)
                .Skip((numeroPagina - 1) * Constantes.QUANTIDADE_ITEMS_PAGINA)
                .Take(Constantes.QUANTIDADE_ITEMS_PAGINA)
                .ToListAsync();
        }
    }
}
