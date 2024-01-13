using Microsoft.EntityFrameworkCore;
using NexusAPI.Compartilhado.Data;

namespace NexusAPI.Compartilhado.EntidadesBase
{
    /// <summary>
    /// CRUD básico para as tabelas da aplicação.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseRepository<T> where T : BaseObjeto
    {
        private readonly DataContext dataContext;

        public BaseRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public async Task<T?> ObterPorIdAsync(string UID)
        {
            return await dataContext.Set<T>()
                .FirstAsync(obj => obj.UID.Equals(UID) && obj.DataFinalizacao == null);
        }

        public async Task<List<T>> ObterTudoAsync()
        {
            return await dataContext.Set<T>()
                .Where(obj => obj.DataFinalizacao == null).ToListAsync();
        }

        public async Task<T> AdicionarAsync(T obj)
        {
            await dataContext.Set<T>().AddAsync(obj);
            await dataContext.SaveChangesAsync();

            return obj;
        }

        public async Task<T> EditarAsync(T obj)
        {
            dataContext.Set<T>().Update(obj);
            await dataContext.SaveChangesAsync();

            return obj;
        }

        public async Task DeletarAsync(T obj)
        {
            obj.DataFinalizacao = DateTime.Now;
            dataContext.Set<T>().Update(obj);
            await dataContext.SaveChangesAsync();
        }
    }
}
