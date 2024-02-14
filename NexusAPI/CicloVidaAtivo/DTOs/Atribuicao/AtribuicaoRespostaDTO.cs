using NexusAPI.CicloVidaAtivo.Enums;
using NexusAPI.Compartilhado.EntidadesBase.DTOs;
using NexusAPI.Compartilhado.EntidadesBase.Objetos;

namespace NexusAPI.CicloVidaAtivo.DTOs.Atribuicao
{
    public class AtribuicaoRespostaDTO : NexusRespostaDTO
    {
        public NexusReferenciaObjeto Usuario { get; set; } = new NexusReferenciaObjeto();

        public NexusReferenciaObjeto Tipo { get; set; } = new NexusReferenciaObjeto();

        public DateTime DataVencimento { get; set; }

        public bool Concluida { get; set; }

        public NexusReferenciaObjeto Objeto { get; set; } = new NexusReferenciaObjeto();

        public NexusReferenciaObjeto Projeto { get; set; } = new NexusReferenciaObjeto();
    }
}
