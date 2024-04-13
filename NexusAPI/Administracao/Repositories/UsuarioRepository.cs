using Microsoft.EntityFrameworkCore;
using NexusAPI.Administracao.Models;
using NexusAPI.Compartilhado.Data;
using NexusAPI.Compartilhado.EntidadesBase.MVC;
using NexusAPI.Compartilhado.Interfaces;

namespace NexusAPI.Administracao.Repositories
{
    public class UsuarioRepository : NexusRepository<Usuario>
    {
        public UsuarioRepository(DataContext dataContext) : base(dataContext)
        {

        }

        /// <summary>
        /// Obtém apenas os registros não finalizados, que contém o nome especificado, 
        /// ordenados por dataCriacao mais recente e
        /// apenas um determinado numero de itens por página.
        /// </summary>
        /// <param name="numeroPagina"></param>
        /// <param name="nome"></param>
        /// <returns></returns>
        public virtual async Task<List<Usuario>> ObterCoordenadoresPorNomeAsync(string nome, string projetoUID)
        {
            return await dataContext.Set<UsuarioPerfil>()
               .Include(obj => obj.AtualizadoPor)
               .Include(obj => obj.UsuarioCriador)
               .Include(obj => obj.Usuario)
               .Include(obj => obj.Projeto)
               .Include(obj => obj.Perfil)
               .Where(obj => obj.DataFinalizacao == null && obj.PerfilUID.Equals("coordenador") && obj.ProjetoUID.Equals(projetoUID))
               .Join(dataContext.Set<Usuario>(), usuarioPerfil => usuarioPerfil.UsuarioUID, usuario => usuario.UID, (usuarioPerfil, usuario) => usuario)
               .ToListAsync();
        }


        public async Task<Usuario?> ObterPorNomeAcessoAsync(string nomeAcesso)
        {
            //EF não suporta comparações com case sensitive, logo, é feita a lógica abaixo.
            var usuario = await dataContext.Set<Usuario>()
                .Where(obj => obj.NomeAcesso.Equals(nomeAcesso) && obj.DataFinalizacao == null)
                .FirstOrDefaultAsync();

            return usuario == null || !usuario.NomeAcesso.Equals(nomeAcesso, StringComparison.Ordinal) ? null : usuario;
        }
    }
}
