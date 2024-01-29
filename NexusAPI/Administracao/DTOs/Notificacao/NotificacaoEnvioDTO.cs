using NexusAPI.Compartilhado.EntidadesBase.DTOs;

namespace NexusAPI.Administracao.DTOs.Notificacao
{
    public class NotificacaoEnvioDTO : NexusEnvioDTO
    {
        public string UsuarioUID { get; set; } = "";

        public bool Vista { get; set; }
    }
}
