using NexusAPI.Compartilhado.EntidadesBase.DTOs;
using NexusAPI.Compartilhado.EntidadesBase.Objetos;

namespace NexusAPI.Dados.DTOs.Software
{
    public class SoftwareRespostaDTO : NexusRespostaDTO
    {
        public NexusReferenciaObjeto Componente { get; set; } = new NexusReferenciaObjeto();

        public NexusReferenciaObjeto Projeto { get; set; } = new NexusReferenciaObjeto();

        public string ChaveLicenca { get; set; } = "";

        public DateTime? DataVencimento { get; set; }
    }
}
