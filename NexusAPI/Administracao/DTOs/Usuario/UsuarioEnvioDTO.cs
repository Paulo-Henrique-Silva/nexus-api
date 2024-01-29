using NexusAPI.Compartilhado.EntidadesBase.DTOs;

namespace NexusAPI.Administracao.DTOs.Usuario
{
    public class UsuarioEnvioDTO : NexusEnvioDTO
    {
        public string NomeAcesso { get; set; } = "";

        public string Senha { get; set; } = "";
    }
}
