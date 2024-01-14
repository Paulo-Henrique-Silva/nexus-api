using Microsoft.EntityFrameworkCore;
using NexusAPI.Compartilhado.Data;
using NexusAPI.Compartilhado.Interfaces;

namespace NexusAPI.Compartilhado.EntidadesBase
{
    /// <summary>
    /// CRUD básico para as tabelas da aplicação.
    /// </summary>
    /// <typeparam name="T">Model da aplicação.</typeparam>
    public abstract class BaseRepository<T> where T : BaseObjeto
    {
        protected readonly DataContext dataContext;

        public BaseRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public virtual async Task<T?> ObterPorIdAsync(string UID)
        {
            return await dataContext.Set<T>()
                .FirstOrDefaultAsync(obj => obj.UID.Equals(UID) && obj.DataFinalizacao == null);
        }
        
        /// <summary>
        /// Obtém apenas os registros não finalizados, ordenados por dataCriacao mais recente e
        /// apenas um determinado numero de itens por página.
        /// </summary>
        /// <param name="numeroPagina"></param>
        /// <returns></returns>
        public virtual async Task<List<T>> ObterTudoAsync(int numeroPagina)
        {
            return await dataContext.Set<T>()
                .Where(obj => obj.DataFinalizacao == null)
                .OrderBy(obj => obj.DataCriacao)
                .Skip((numeroPagina - 1) * Constantes.QUANTIDADE_ITEMS_PAGINA)
                .Take(Constantes.QUANTIDADE_ITEMS_PAGINA)
                .ToListAsync();
        }

        public virtual async Task<T> AdicionarAsync(T obj)
        {
            obj.DataCriacao = DateTime.Now;
            await dataContext.Set<T>().AddAsync(obj);
            await dataContext.SaveChangesAsync();

            return obj;
        }

        public virtual async Task<T> EditarAsync(T obj)
        {
            obj.DataUltimaAtualizacao = DateTime.Now;
            dataContext.Set<T>().Update(obj);
            await dataContext.SaveChangesAsync();

            return obj;
        }

        public virtual async Task DeletarAsync(T obj)
        {
            obj.DataFinalizacao = DateTime.Now;
            dataContext.Set<T>().Update(obj);
            await dataContext.SaveChangesAsync();
        }
    }
}
