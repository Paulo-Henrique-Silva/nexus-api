using NexusAPI.Compartilhado.EntidadesBase;

namespace NexusAPI.Administracao.DTOs
{
    public class UsuarioRespostaDTO : NexusObjetoRespostaDTO
    {
        public string NomeAcesso { get; set; } = "";

        public TokenDTO? Token { get; set; }
    }
}
