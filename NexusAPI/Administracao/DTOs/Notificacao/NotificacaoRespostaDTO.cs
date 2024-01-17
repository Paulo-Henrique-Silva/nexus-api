using NexusAPI.Compartilhado.EntidadesBase;

namespace NexusAPI.Administracao.DTOs.Notificacao
{
    public class NotificacaoRespostaDTO : NexusRespostaDTO
    {
        public NexusNomeObjeto Usuario { get; set; } = new NexusNomeObjeto();

        public bool Vista { get; set; }
    }
}
