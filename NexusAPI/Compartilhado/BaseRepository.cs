using Microsoft.EntityFrameworkCore;

namespace NexusAPI.Compartilhado
{
    public class BaseRepository<T> where T : ObjetoNexus
    {
        public DataContext DataContext { get; set; }

        public BaseRepository(DataContext dataContext)
        {
            DataContext = dataContext;
        }

        public async Task<T?> ObterPorId(string UID)
        {
            return await DataContext.Set<T>()
                .FirstAsync(obj => obj.UID.Equals(UID) && obj.DataFinalizacao == null);
        }

        public async Task<List<T>> ObterTudo()
        {
            return await DataContext.Set<T>()
                .Where(obj => obj.DataFinalizacao == null).ToListAsync();
        }

        public async Task<T> Adicionar(T obj)
        {
            await DataContext.Set<T>().AddAsync(obj);
            await DataContext.SaveChangesAsync();

            return obj;
        }

        public async Task<T> Editar(T obj)
        {
            DataContext.Set<T>().Update(obj);
            await DataContext.SaveChangesAsync();

            return obj;
        }

        public async Task Deletar(T obj)
        {
            obj.DataFinalizacao = DateTime.Now;
            DataContext.Set<T>().Update(obj);
            await DataContext.SaveChangesAsync();
        }
    }
}
