using NexusAPI.Compartilhado.EntidadesBase.DTOs;
using NexusAPI.Compartilhado.EntidadesBase.Objetos;

namespace NexusAPI.Administracao.DTOs.Notificacao
{
    public class NotificacaoRespostaDTO : NexusRespostaDTO
    {
        public NexusReferenciaObjeto Usuario { get; set; } = new NexusReferenciaObjeto();

        public bool Vista { get; set; }
    }
}
