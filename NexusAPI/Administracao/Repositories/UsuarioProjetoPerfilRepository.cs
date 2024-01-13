using Microsoft.EntityFrameworkCore;
using NexusAPI.Administracao.Models;
using NexusAPI.Compartilhado.Data;

namespace NexusAPI.Administracao.Repositories
{
    public class UsuarioProjetoPerfilRepository
    {
        public DataContext DataContext { get; set; }

        public UsuarioProjetoPerfilRepository(DataContext dataContext)
        {
            DataContext = dataContext;
        }

        public async Task<UsuarioProjetoPerfil> ObterPorId(string usuarioUID, 
            string projetoUID, string perfilUID)
        {
            return await DataContext.Set<UsuarioProjetoPerfil>()
                .FirstAsync(obj => obj.UsuarioUID.Equals(usuarioUID) &&
                    obj.ProjetoUID.Equals(projetoUID) && obj.PerfilUID.Equals(perfilUID)
                    && obj.DataFinalizacao == null);
        }

        public async Task<List<UsuarioProjetoPerfil>> ObterTudo()
        {
            return await DataContext.Set<UsuarioProjetoPerfil>()
                .Where(obj => obj.DataFinalizacao == null).ToListAsync();
        }

        public async Task<UsuarioProjetoPerfil> Adicionar(UsuarioProjetoPerfil obj)
        {
            await DataContext.Set<UsuarioProjetoPerfil>().AddAsync(obj);
            await DataContext.SaveChangesAsync();

            return obj;
        }

        public async Task<UsuarioProjetoPerfil> Editar(UsuarioProjetoPerfil obj)
        {
            DataContext.Set<UsuarioProjetoPerfil>().Update(obj);
            await DataContext.SaveChangesAsync();

            return obj;
        }

        public async Task Deletar(UsuarioProjetoPerfil obj)
        {
            obj.DataFinalizacao = DateTime.Now;
            DataContext.Set<UsuarioProjetoPerfil>().Update(obj);
            await DataContext.SaveChangesAsync();
        }
    }
}
