using NexusAPI.Compartilhado.EntidadesBase;

namespace NexusAPI.Administracao.DTOs.Notificacao
{
    public class NotificacaoEnvioDTO : NexusEnvioDTO
    {
        public string? UsuarioUID { get; set; }
    }
}
