using NexusAPI.Compartilhado.EntidadesBase.DTOs;
using NexusAPI.Compartilhado.EntidadesBase.Objetos;

namespace NexusAPI.Dados.DTOs.Requisicao
{
    public class RequisicaoRespostaDTO : NexusRespostaDTO
    {
        public NexusNomeObjeto Coordenador { get; set; } = new NexusNomeObjeto();

        public NexusNomeObjeto Projeto { get; set; } = new NexusNomeObjeto();
    }
}
