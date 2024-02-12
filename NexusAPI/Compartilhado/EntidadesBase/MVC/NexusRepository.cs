using BCrypt.Net;
using Microsoft.EntityFrameworkCore;
using NexusAPI.Compartilhado.Data;
using NexusAPI.Compartilhado.Interfaces;

namespace NexusAPI.Compartilhado.EntidadesBase.MVC
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
        public virtual async Task<List<T>> ObterTudoAsync(int numeroPagina)
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

        /// <summary>
        /// Obtém apenas os registros não finalizados, que contém o nome especificado, 
        /// ordenados por dataCriacao mais recente e
        /// apenas um determinado numero de itens por página.
        /// </summary>
        /// <param name="numeroPagina"></param>
        /// <param name="nome"></param>
        /// <returns></returns>
        public virtual async Task<List<T>> ObterTudoPorNomeAsync(int numeroPagina, string nome)
        {
            return await dataContext.Set<T>()
                .Include(obj => obj.AtualizadoPor)
                .Include(obj => obj.UsuarioCriador)
                .Where(obj => obj.DataFinalizacao == null && obj.Nome.Contains(nome))
                .OrderByDescending(obj => obj.DataCriacao)
                .Skip((numeroPagina - 1) * Constantes.QUANTIDADE_ITEMS_PAGINA)
                .Take(Constantes.QUANTIDADE_ITEMS_PAGINA)
                .ToListAsync();
        }

        /// <summary>
        /// Obtém a quantidade itens não finalizados.
        /// </summary>
        /// <param name="numeroPagina"></param>
        /// <returns></returns>
        public virtual async Task<int> ObterCountAsync()
        {
            return await dataContext.Set<T>().Where(obj => obj.DataFinalizacao == null).CountAsync();
        }

        /// <summary>
        /// Obtém a quantidade itens não finalizados por nome
        /// </summary>
        /// <param name="numeroPagina"></param>
        /// <returns></returns>
        public virtual async Task<int> ObterCountPorNomeAsync(string nome)
        {
            return await dataContext.Set<T>()
                .Where(obj => obj.DataFinalizacao == null && obj.Nome.Contains(nome))
                .CountAsync();
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
                var valorExistente = property.GetValue(objExistente);

                //Transforma strings vazias e datas mínimas em null.
                if (valorAtualizado is string && valorAtualizado.Equals(string.Empty) &&
                    valorExistente is string && valorExistente.Equals(string.Empty) ||
                    valorAtualizado is DateTime && valorAtualizado.Equals(DateTime.MinValue))
                {
                    valorAtualizado = null;
                }

                //Se for uma string hash que representa vazio.
                if (property.Name.Equals("Senha") && valorAtualizado is string &&
                    BCrypt.Net.BCrypt.Verify("", valorAtualizado.ToString()))
                {
                    valorAtualizado = null;
                }

                // Verificar e tratar nulos e cadeias de caracteres vazias
                if (valorAtualizado != null && !valorAtualizado.Equals(valorExistente))
                {
                    property.SetValue(objExistente, valorAtualizado);
                }
            }
        }

    }
}
