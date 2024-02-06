using NexusAPI.Compartilhado.EntidadesBase.DTOs;
using NexusAPI.Compartilhado.EntidadesBase.Objetos;

namespace NexusAPI.Dados.DTOs.Requisicao
{
    public class RequisicaoRespostaDTO : NexusRespostaDTO
    {
        public NexusReferenciaObjeto Coordenador { get; set; } = new NexusReferenciaObjeto();

        public NexusReferenciaObjeto Projeto { get; set; } = new NexusReferenciaObjeto();
    }
}
