using Microsoft.EntityFrameworkCore;
using NexusAPI.Administracao.Models;
using NexusAPI.CicloVidaAtivo.Models;
using NexusAPI.Compartilhado.Data;
using NexusAPI.Compartilhado.EntidadesBase.MVC;
using NexusAPI.Compartilhado.Interfaces;
using NexusAPI.Dados.Interfaces;
using NexusAPI.Dados.Models;

namespace NexusAPI.Dados.Repositories
{
    public class ComponenteRepository : NexusRepository<Componente>, 
        IProjetoItemRepository<Componente>
    {
        public ComponenteRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public override async Task<Componente?> ObterPorUIDAsync(string UID)
        {
            return await dataContext.Set<Componente>()
                .Include(obj => obj.AtualizadoPor)
                .Include(obj => obj.UsuarioCriador)
                .Include(obj => obj.Localizacao)
                .Include(obj => obj.Projeto)
                .FirstOrDefaultAsync(obj => obj.UID.Equals(UID) && obj.DataFinalizacao == null);
        }

        public override async Task<List<Componente>> ObterTudoAsync(int numeroPagina)
        {
            return await dataContext.Set<Componente>()
                .Include(obj => obj.AtualizadoPor)
                .Include(obj => obj.UsuarioCriador)
                .Include(obj => obj.Localizacao)
                .Include(obj => obj.Projeto)
                .Where(obj => obj.DataFinalizacao == null)
                .OrderByDescending(obj => obj.DataCriacao)
                .Skip((numeroPagina - 1) * Constantes.QUANTIDADE_ITEMS_PAGINA)
                .Take(Constantes.QUANTIDADE_ITEMS_PAGINA)
                .ToListAsync();
        }

        /// <summary>
        /// Obtém a quantidade itens não finalizados, pelo projeto especificado.
        /// </summary>
        /// <param name="numeroPagina"></param>
        /// <returns></returns>
        public virtual async Task<int> ObterCountPorProjetoUIDAsync(string projetoUID)
        {
            return await dataContext.Set<Componente>()
                .Where(obj => obj.DataFinalizacao == null && obj.ProjetoUID.Equals(projetoUID))
                .CountAsync();
        }

        public async Task<List<Componente>> ObterTudoPorProjetoUIDAsync(int numeroPagina,
            string projetoUID)
        {
            return await dataContext.Set<Componente>()
                .Include(obj => obj.AtualizadoPor)
                .Include(obj => obj.UsuarioCriador)
                .Include(obj => obj.Localizacao)
                .Include(obj => obj.Projeto)
                .Where(obj => obj.DataFinalizacao == null && obj.ProjetoUID.Equals(projetoUID))
                .OrderByDescending(obj => obj.DataCriacao)
                .Skip((numeroPagina - 1) * Constantes.QUANTIDADE_ITEMS_PAGINA)
                .Take(Constantes.QUANTIDADE_ITEMS_PAGINA)
                .ToListAsync();
        }
    }
}
