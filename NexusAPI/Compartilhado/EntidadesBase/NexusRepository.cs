using Microsoft.EntityFrameworkCore;
using NexusAPI.Administracao.Models;
using NexusAPI.Compartilhado.Data;
using NexusAPI.Compartilhado.Interfaces;

namespace NexusAPI.Compartilhado.EntidadesBase
{
    /// <summary>
    /// CRUD básico para as tabelas da aplicação.
    /// </summary>
    /// <typeparam name="T">Model da aplicação.</typeparam>
    public abstract class NexusRepository<T> where T : NexusObjeto
    {
        protected readonly DataContext dataContext;

        public NexusRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public virtual async Task<T?> ObterPorUIDAsync(string UID)
        {
            return await dataContext.Set<T>()
                .Include(obj => obj.AtualizadoPor)
                .Include(obj => obj.UsuarioCriador)
                .FirstOrDefaultAsync(obj => obj.UID.Equals(UID) && obj.DataFinalizacao == null);
        }
        
        /// <summary>
        /// Obtém apenas os registros não finalizados, ordenados por dataCriacao mais recente e
        /// apenas um determinado numero de itens por página.
        /// </summary>
        /// <param name="numeroPagina"></param>
        /// <returns></returns>
        public virtual async Task<List<T>> ObterTudoUIDAsync(int numeroPagina)
        {
            return await dataContext.Set<T>()
                .Include(obj => obj.AtualizadoPor)
                .Include(obj => obj.UsuarioCriador)
                .Where(obj => obj.DataFinalizacao == null)
                .OrderByDescending(obj => obj.DataCriacao)
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
            var objExistente = dataContext.Set<T>().Find(obj.UID);

            if (objExistente != null)
            {
                EditarApenasCamposDiferentes(objExistente, obj);

                objExistente.DataUltimaAtualizacao = DateTime.Now;
                dataContext.Set<T>().Update(objExistente);
                await dataContext.SaveChangesAsync();

                return objExistente;
            }

            return obj;
        }

        public virtual async Task DeletarAsync(T obj)
        {
            var objExistente = dataContext.Set<T>().Find(obj.UID);

            if (objExistente != null)
            {
                objExistente.DataFinalizacao = DateTime.Now;

                dataContext.Set<T>().Update(objExistente);
                await dataContext.SaveChangesAsync();
            }
        }

        public virtual void EditarApenasCamposDiferentes(T objExistente, T objAtualizado)
        {
            var properties = typeof(T).GetProperties();

            foreach (var property in properties)
            {
                var valorAtualizado = property.GetValue(objAtualizado);

                //Transforma strings vazias e datas mínimas em null.
                if ((valorAtualizado is string && valorAtualizado.Equals(string.Empty)) ||
                    (valorAtualizado is DateTime && valorAtualizado.Equals(DateTime.MinValue)))
                {
                    valorAtualizado = null;
                }

                var valorExistente = property.GetValue(objExistente);

                // Verificar e tratar nulos e cadeias de caracteres vazias
                if (valorAtualizado != null && !valorAtualizado.Equals(valorExistente))
                {
                    property.SetValue(objExistente, valorAtualizado);
                }
            }
        }

    }
}
