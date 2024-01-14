using NexusAPI.Compartilhado.EntidadesBase;

namespace NexusAPI.Administracao.DTOs.Usuario
{
    public class UsuarioRespostaDTO : NexusRespostaDTO
    {
        public string NomeAcesso { get; set; } = "";

        public TokenDTO? Token { get; set; }
    }
}
