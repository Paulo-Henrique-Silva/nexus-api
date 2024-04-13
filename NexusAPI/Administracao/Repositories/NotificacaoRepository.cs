using Microsoft.EntityFrameworkCore;
using NexusAPI.Administracao.Models;
using NexusAPI.Compartilhado.Data;
using NexusAPI.Compartilhado.EntidadesBase.MVC;
using NexusAPI.Compartilhado.Interfaces;

namespace NexusAPI.Administracao.Repositories
{
    public class NotificacaoRepository : NexusRepository<Notificacao>
    {
        public NotificacaoRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public override async Task<Notificacao?> ObterPorUIDAsync(string UID)
        {
            return await dataContext.Set<Notificacao>()
                .Include(obj => obj.AtualizadoPor)
                .Include(obj => obj.UsuarioCriador)
                .Include(obj => obj.Usuario)
                .FirstOrDefaultAsync(obj => obj.UID.Equals(UID) && obj.DataFinalizacao == null);
        }

        public override async Task<List<Notificacao>> ObterTudoAsync(int? numeroPagina)
        {
            int pagina = numeroPagina.HasValue ? (int)numeroPagina : 1;

            return await dataContext.Set<Notificacao>()
                .Include(obj => obj.AtualizadoPor)
                .Include(obj => obj.UsuarioCriador)
                .Include(obj => obj.Usuario)
                .Where(obj => obj.DataFinalizacao == null)
                .OrderByDescending(obj => obj.DataCriacao)
                .Skip((pagina - 1) * Constantes.QUANTIDADE_ITEMS_PAGINA)
                .Take(Constantes.QUANTIDADE_ITEMS_PAGINA)
                .ToListAsync();
        }

        /// <summary>
        /// Retorna as notificações por usuário UID. Não tem paginação para facilitar a performace.
        /// </summary>
        /// <param name="usuarioUID"></param>
        /// <returns></returns>
        public async Task<List<Notificacao>> ObterTudoPorUsuarioUIDAsync(string usuarioUID)
        {
            return await dataContext.Set<Notificacao>()
                .Include(obj => obj.AtualizadoPor)
                .Include(obj => obj.UsuarioCriador)
                .Include(obj => obj.Usuario)
                .Where(obj => obj.DataFinalizacao == null && obj.UsuarioUID.Equals(usuarioUID))
                .OrderByDescending(obj => obj.DataCriacao)
                .ToListAsync();
        }
    }
}
