using NexusAPI.Compartilhado.EntidadesBase;

namespace NexusAPI.Dados.DTOs.Requisicao
{
    public class RequisicaoRespostaDTO : NexusRespostaDTO
    {
        public NexusNomeObjeto Coordenador { get; set; } = new NexusNomeObjeto();
    }
}
