using NexusAPI.Compartilhado.EntidadesBase;

namespace NexusAPI.Administracao.DTOs.Usuario
{
    public class UsuarioEnvioDTO : NexusEnvioDTO
    {
        public string NomeAcesso { get; set; } = "";

        public string Senha { get; set; } = "";
    }
}
