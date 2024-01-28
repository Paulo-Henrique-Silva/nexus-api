using Microsoft.EntityFrameworkCore;
using NexusAPI.Administracao.Models;
using NexusAPI.Compartilhado.Data;
using NexusAPI.Compartilhado.EntidadesBase;
using NexusAPI.Compartilhado.Interfaces;

namespace NexusAPI.Administracao.Repositories
{
    public class UsuarioRepository : NexusRepository<Usuario>
    {
        public UsuarioRepository(DataContext dataContext) : base(dataContext)
        {

        }

        public async Task<Usuario?> ObterPorNomeAcessoAsync(string nomeAcesso)
        {
            return await dataContext.Set<Usuario>()
                .Where(obj => obj.NomeAcesso.Equals(nomeAcesso, StringComparison.Ordinal) && obj.DataFinalizacao == null)
                .FirstOrDefaultAsync();
        }
    }
}
