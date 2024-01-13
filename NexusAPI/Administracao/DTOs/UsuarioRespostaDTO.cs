using NexusAPI.Compartilhado.EntidadesBase;

namespace NexusAPI.Administracao.DTOs
{
    public class UsuarioRespostaDTO : BaseRespostaDTO
    {
        public string NomeAcesso { get; set; } = "";

        public string Senha { get; set; } = "";
    }
}
