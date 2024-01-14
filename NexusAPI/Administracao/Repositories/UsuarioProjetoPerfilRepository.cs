using Microsoft.EntityFrameworkCore;
using NexusAPI.Administracao.Models;
using NexusAPI.Compartilhado.Data;
using NexusAPI.Compartilhado.Interfaces;

namespace NexusAPI.Administracao.Repositories
{
    public class UsuarioProjetoPerfilRepository
    {
        public DataContext DataContext { get; set; }

        public UsuarioProjetoPerfilRepository(DataContext dataContext)
        {
            DataContext = dataContext;
        }

        public async Task<UsuarioProjetoPerfil> ObterPorUIDAsync(string usuarioUID, 
            string projetoUID, string perfilUID)
        {
            return await DataContext.Set<UsuarioProjetoPerfil>()
                .FirstAsync(obj => obj.UsuarioUID.Equals(usuarioUID) &&
                    obj.ProjetoUID.Equals(projetoUID) && obj.PerfilUID.Equals(perfilUID)
                    && obj.DataFinalizacao == null);
        }

        public async Task<List<UsuarioProjetoPerfil>> ObterTudoAsync(int numeroPagina)
        {
            return await DataContext.Set<UsuarioProjetoPerfil>()
                .Where(obj => obj.DataFinalizacao == null)
                .OrderBy(obj => obj.DataCriacao)
                .Skip((numeroPagina - 1) * Constantes.QUANTIDADE_ITEMS_PAGINA)
                .Take(Constantes.QUANTIDADE_ITEMS_PAGINA)
                .ToListAsync();
        }

        public async Task<UsuarioProjetoPerfil> AdicionarAsync(UsuarioProjetoPerfil obj)
        {
            await DataContext.Set<UsuarioProjetoPerfil>().AddAsync(obj);
            await DataContext.SaveChangesAsync();

            return obj;
        }

        public async Task<UsuarioProjetoPerfil> EditarAsync(UsuarioProjetoPerfil obj)
        {
            DataContext.Set<UsuarioProjetoPerfil>().Update(obj);
            await DataContext.SaveChangesAsync();

            return obj;
        }

        public async Task DeletarAsync(UsuarioProjetoPerfil obj)
        {
            obj.DataFinalizacao = DateTime.Now;
            DataContext.Set<UsuarioProjetoPerfil>().Update(obj);
            await DataContext.SaveChangesAsync();
        }
    }
}
