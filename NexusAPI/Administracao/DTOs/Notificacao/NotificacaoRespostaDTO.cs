using NexusAPI.Compartilhado.EntidadesBase;

namespace NexusAPI.Administracao.DTOs.Notificacao
{
    public class NotificacaoRespostaDTO : NexusRespostaDTO
    {
        public string UsuarioUID { get; set; } = "";
    }
}
