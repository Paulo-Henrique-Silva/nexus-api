using NexusAPI.Administracao.Models;
using NexusAPI.Administracao.Repositories;
using NexusAPI.Compartilhado.EntidadesBase;

namespace NexusAPI.Administracao.Services
{
    public class UsuariosService : IBaseService<Usuario>
    {
        private readonly UsuarioRepository usuarioRepository;

        public UsuariosService(UsuarioRepository usuarioRepository)
        {
            this.usuarioRepository = usuarioRepository;
        }

        public Task<Usuario> Adicionar(Usuario obj)
        {
            throw new NotImplementedException();
        }

        public Task Deletar(Usuario obj)
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> Editar(Usuario obj)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistePorUID(string UID)
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> ObterPorIdAsync(string UID)
        {
            throw new NotImplementedException();
        }

        public Task<List<Usuario>> ObterTudoAsync()
        {
            throw new NotImplementedException();
        }
    }
}
