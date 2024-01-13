using NexusAPI.Administracao.DTOs;
using NexusAPI.Administracao.Models;
using NexusAPI.Administracao.Repositories;
using NexusAPI.Compartilhado.EntidadesBase;

namespace NexusAPI.Administracao.Services
{
    public class UsuariosService : IBaseService<UsuarioEnvioDTO, UsuarioRespostaDTO>
    {
        private readonly UsuarioRepository usuarioRepository;

        public UsuariosService(UsuarioRepository usuarioRepository)
        {
            this.usuarioRepository = usuarioRepository;
        }

        public Task<UsuarioRespostaDTO> Adicionar(UsuarioEnvioDTO obj)
        {
            throw new NotImplementedException();
        }

        public Task Deletar(UsuarioEnvioDTO obj)
        {
            throw new NotImplementedException();
        }

        public Task<UsuarioRespostaDTO> Editar(UsuarioEnvioDTO obj)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistePorUID(string UID)
        {
            throw new NotImplementedException();
        }

        public Task<UsuarioRespostaDTO> ObterPorIdAsync(string UID)
        {
            throw new NotImplementedException();
        }

        public Task<List<UsuarioRespostaDTO>> ObterTudoAsync()
        {
            throw new NotImplementedException();
        }
    }
}
