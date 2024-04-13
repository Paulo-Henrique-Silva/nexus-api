using Microsoft.EntityFrameworkCore;
using NexusAPI.Administracao.Models;
using NexusAPI.CicloVidaAtivo.Models;
using NexusAPI.Compartilhado.Data;
using NexusAPI.Compartilhado.EntidadesBase.MVC;
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
                .Include(obj => obj.Projeto)
                .FirstOrDefaultAsync(obj => obj.UID.Equals(UID) && obj.DataFinalizacao == null);
        }

        public override async Task<List<Atribuicao>> ObterTudoAsync(int? numeroPagina)
        {
            int pagina = numeroPagina.HasValue ? (int)numeroPagina : 1;

            return await dataContext.Set<Atribuicao>()
                .Include(obj => obj.AtualizadoPor)
                .Include(obj => obj.UsuarioCriador)
                .Include(obj => obj.Usuario)
                .Include(obj => obj.Projeto)
                .Where(obj => obj.DataFinalizacao == null)
                .OrderByDescending(obj => obj.DataCriacao)
                .Skip((pagina - 1) * Constantes.QUANTIDADE_ITEMS_PAGINA)
                .Take(Constantes.QUANTIDADE_ITEMS_PAGINA)
                .ToListAsync();
        }


        /// <summary>
        /// Obtém as atribuições que tem como responsável o usuário de UID especificado.
        /// Obs: A paginação foi retirada desse item para facilitar o desenvolvimento, contudo,
        /// no futuro do trabalho é interessante isso ser aplicado.
        /// </summary>
        /// <param name="usuarioUID"></param>
        /// <returns></returns>
        public async Task<List<Atribuicao>> ObterTudoPorUsuarioUIDAsync(string usuarioUID)
        {
            return await dataContext.Set<Atribuicao>()
                .Include(obj => obj.AtualizadoPor)
                .Include(obj => obj.UsuarioCriador)
                .Include(obj => obj.Usuario)
                .Include(obj => obj.Projeto)
                .Where(obj => obj.DataFinalizacao == null && obj.UsuarioUID.Equals(usuarioUID))
                .OrderByDescending(obj => obj.DataCriacao)
                .ToListAsync();
        }
    }
}
