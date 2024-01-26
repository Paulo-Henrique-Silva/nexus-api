using NexusAPI.Compartilhado.EntidadesBase;

namespace NexusAPI.Administracao.DTOs.Usuario
{
    public class UsuarioRespostaDTO : NexusRespostaDTO
    {
        public string NomeAcesso { get; set; } = "";

        public string? Token { get; set; }
    }
}
