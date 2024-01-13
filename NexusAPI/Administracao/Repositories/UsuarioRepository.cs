using Microsoft.EntityFrameworkCore;
using NexusAPI.Administracao.Models;
using NexusAPI.Compartilhado.Data;
using NexusAPI.Compartilhado.EntidadesBase;
using NexusAPI.Compartilhado.Interfaces;

namespace NexusAPI.Administracao.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>
    {
        public UsuarioRepository(DataContext dataContext) : base(dataContext)
        {

        }

        public async Task<Usuario?> ObterPorNomeAcesso(string nomeAcesso)
        {
            return await dataContext.Set<Usuario>()
                .Where(obj => obj.NomeAcesso.Equals(nomeAcesso))
                .FirstOrDefaultAsync();
        }
    }
}
