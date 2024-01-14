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
                .OrderBy(obj => obj.DataCriacao)
                .Skip((numeroPagina - 1) * Constantes.QUANTIDADE_ITEMS_PAGINA)
                .Take(Constantes.QUANTIDADE_ITEMS_PAGINA)
                .ToListAsync();
        }

        public async Task<UsuarioPerfil> AdicionarAsync(UsuarioPerfil obj)
        {
            await dataContext.Set<UsuarioPerfil>().AddAsync(obj);
            await dataContext.SaveChangesAsync();

            return obj;
        }

        public async Task<UsuarioPerfil> EditarAsync(UsuarioPerfil obj)
        {
            dataContext.Set<UsuarioPerfil>().Update(obj);
            await dataContext.SaveChangesAsync();

            return obj;
        }

        public async Task DeletarAsync(UsuarioPerfil obj)
        {
            obj.DataFinalizacao = DateTime.Now;
            dataContext.Set<UsuarioPerfil>().Update(obj);
            await dataContext.SaveChangesAsync();
        }
    }
}
