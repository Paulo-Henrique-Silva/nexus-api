using Microsoft.EntityFrameworkCore;
using NexusAPI.Compartilhado.Data;
using NexusAPI.Compartilhado.EntidadesBase.MVC;
using NexusAPI.Compartilhado.Interfaces;
using NexusAPI.Dados.Interfaces;
using NexusAPI.Dados.Models;
using System.Linq;

namespace NexusAPI.Dados.Repositories
{
    public class RequisicaoRepository : NexusRepository<Requisicao>, IProjetoItemRepository<Requisicao>
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
                .Include(obj => obj.Projeto)
                .FirstOrDefaultAsync(obj => obj.UID.Equals(UID) && obj.DataFinalizacao == null);
        }

        public override async Task<List<Requisicao>> ObterTudoAsync(int? numeroPagina)
        {
            int pagina = numeroPagina.HasValue ? (int)numeroPagina : 1;

            return await dataContext.Set<Requisicao>()
                .Include(obj => obj.AtualizadoPor)
                .Include(obj => obj.UsuarioCriador)
                .Include(obj => obj.Coordenador)
                .Include(obj => obj.Projeto)
                .Where(obj => obj.DataFinalizacao == null)
                .OrderByDescending(obj => obj.DataCriacao)
                .Skip((pagina - 1) * Constantes.QUANTIDADE_ITEMS_PAGINA)
                .Take(Constantes.QUANTIDADE_ITEMS_PAGINA)
                .ToListAsync();
        }

        public override async Task<List<Requisicao>> ObterTudoPorNomeAsync(string nome, int? numeroPagina)
        {
            int pagina = numeroPagina.HasValue ? (int)numeroPagina : 1;

            return await dataContext.Set<Requisicao>()
                .Include(obj => obj.AtualizadoPor)
                .Include(obj => obj.UsuarioCriador)
                .Include(obj => obj.Coordenador)
                .Include(obj => obj.Projeto)
                .Where(obj => obj.DataFinalizacao == null && obj.Nome.Equals(nome))
                .OrderByDescending(obj => obj.DataCriacao)
                .Skip((pagina - 1) * Constantes.QUANTIDADE_ITEMS_PAGINA)
                .Take(Constantes.QUANTIDADE_ITEMS_PAGINA)
                .ToListAsync();
        }

        /// <summary>
        /// Obtém a quantidade itens não finalizados, pelo projeto especificado.
        /// </summary>
        /// <returns></returns>
        public virtual async Task<int> ObterCountPorProjetoUIDAsync(string projetoUID)
        {
            return await dataContext.Set<Requisicao>()
                .Where(obj => obj.DataFinalizacao == null && obj.ProjetoUID.Equals(projetoUID))
                .CountAsync();
        }

        /// <summary>
        /// Obtém a quantidade itens não finalizados, pelo projeto especificado.
        /// </summary>
        /// <param name="numeroPagina"></param>
        /// <returns></returns>
        public virtual async Task<int> ObterCountPorProjetoENomeAsync(string projetoUID, string nome)
        {
            return await dataContext.Set<Requisicao>()
                .Where(obj => obj.DataFinalizacao == null && obj.ProjetoUID.Equals(projetoUID) &&
                obj.Nome.Contains(nome))
                .CountAsync();
        }

        public async Task<List<Requisicao>> ObterTudoPorProjetoUIDAsync(int numeroPagina, 
            string projetoUID)
        {
            return await dataContext.Set<Requisicao>()
                .Include(obj => obj.AtualizadoPor)
                .Include(obj => obj.UsuarioCriador)
                .Include(obj => obj.Coordenador)
                .Include(obj => obj.Projeto)
                .Where(obj => obj.DataFinalizacao == null && obj.ProjetoUID.Equals(projetoUID))
                .OrderByDescending(obj => obj.DataCriacao)
                .Skip((numeroPagina - 1) * Constantes.QUANTIDADE_ITEMS_PAGINA)
                .Take(Constantes.QUANTIDADE_ITEMS_PAGINA)
                .ToListAsync();
        }

        public async Task<List<Requisicao>> ObterTudoPorProjetoENomeAsync(int numeroPagina,
            string projetoUID, string nome)
        {
            return await dataContext.Set<Requisicao>()
                .Include(obj => obj.AtualizadoPor)
                .Include(obj => obj.UsuarioCriador)
                .Include(obj => obj.Coordenador)
                .Include(obj => obj.Projeto)
                .Where(obj => obj.DataFinalizacao == null && obj.ProjetoUID.Equals(projetoUID) &&
                obj.Nome.Contains(nome))
                .OrderByDescending(obj => obj.DataCriacao)
                .Skip((numeroPagina - 1) * Constantes.QUANTIDADE_ITEMS_PAGINA)
                .Take(Constantes.QUANTIDADE_ITEMS_PAGINA)
                .ToListAsync();
        }
    }
}
