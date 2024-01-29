using Microsoft.EntityFrameworkCore;
using NexusAPI.Administracao.Models;
using NexusAPI.Compartilhado.Data;
using NexusAPI.Compartilhado.Interfaces;

namespace NexusAPI.Administracao.Repositories
{
    public class UsuarioPerfilRepository
    {
        private readonly DataContext dataContext;

        public UsuarioPerfilRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public async Task<UsuarioPerfil?> ObterPorUIDAsync(string usuarioUID,
            string projetoUID, string perfilUID)
        {
            return await dataContext.Set<UsuarioPerfil>()
                .Include(obj => obj.AtualizadoPor)
                .Include(obj => obj.UsuarioCriador)
                .Include(obj => obj.Usuario)
                .Include(obj => obj.Projeto)
                .Include(obj => obj.Perfil)
                .FirstOrDefaultAsync(obj => obj.UsuarioUID.Equals(usuarioUID) &&
                obj.ProjetoUID.Equals(projetoUID) &&
                obj.PerfilUID.Equals(perfilUID) &&
                obj.DataFinalizacao == null);
        }

        public async Task<List<UsuarioPerfil>> ObterTudoAsync(int numeroPagina)
        {
            return await dataContext.Set<UsuarioPerfil>()
                .Include(obj => obj.AtualizadoPor)
                .Include(obj => obj.UsuarioCriador)
                .Include(obj => obj.Usuario)
                .Include(obj => obj.Projeto)
                .Include(obj => obj.Perfil)
                .Where(obj => obj.DataFinalizacao == null)
                .OrderByDescending(obj => obj.DataCriacao)
                .Skip((numeroPagina - 1) * Constantes.QUANTIDADE_ITEMS_PAGINA)
                .Take(Constantes.QUANTIDADE_ITEMS_PAGINA)
                .ToListAsync();
        }

        public async Task<List<UsuarioPerfil>> ObterTudoPorUsuarioUIDAsync(string usuarioUID)
        {
            return await dataContext.Set<UsuarioPerfil>()
                .Include(obj => obj.AtualizadoPor)
                .Include(obj => obj.UsuarioCriador)
                .Include(obj => obj.Usuario)
                .Include(obj => obj.Projeto)
                .Include(obj => obj.Perfil)
                .Where(obj => obj.DataFinalizacao == null && obj.UsuarioUID.Equals(usuarioUID))
                .OrderByDescending(obj => obj.DataCriacao)
                .ToListAsync();
        }

        public async Task<UsuarioPerfil> AdicionarAsync(UsuarioPerfil obj)
        {
            obj.DataCriacao = DateTime.Now;
            await dataContext.Set<UsuarioPerfil>().AddAsync(obj);
            await dataContext.SaveChangesAsync();

            return obj;
        }

        public async Task<UsuarioPerfil> EditarAsync(UsuarioPerfil obj)
        {
            var objExistente = dataContext.Set<UsuarioPerfil>()
                .Local
                .FirstOrDefault(obj => obj.UsuarioUID.Equals(obj.UsuarioUID) &&
                obj.ProjetoUID.Equals(obj.ProjetoUID) &&
                obj.PerfilUID.Equals(obj.PerfilUID));

            if (objExistente != null)
            {
                EditarApenasCamposDiferentes(objExistente, obj);

                objExistente.DataUltimaAtualizacao = DateTime.Now;
                dataContext.Set<UsuarioPerfil>().Update(objExistente);
                await dataContext.SaveChangesAsync();

                return objExistente;
            }

            return obj;
        }

        public async Task DeletarAsync(UsuarioPerfil obj)
        {
            var objExistente = dataContext.Set<UsuarioPerfil>()
                .Local
                .FirstOrDefault(obj => obj.UsuarioUID.Equals(obj.UsuarioUID) &&
                obj.ProjetoUID.Equals(obj.ProjetoUID) &&
                obj.PerfilUID.Equals(obj.PerfilUID));

            if (objExistente != null)
            {
                objExistente.DataFinalizacao = DateTime.Now;

                dataContext.Set<UsuarioPerfil>().Update(objExistente);
                await dataContext.SaveChangesAsync();
            }
        }

        public virtual void EditarApenasCamposDiferentes(UsuarioPerfil objExistente, 
            UsuarioPerfil objAtualizado)
        {
            var properties = typeof(UsuarioPerfil).GetProperties();

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
