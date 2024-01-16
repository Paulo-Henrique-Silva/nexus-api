using NexusAPI.Compartilhado.EntidadesBase;

namespace NexusAPI.Dados.DTOs.Software
{
    public class SoftwareRespostaDTO : NexusRespostaDTO
    {
        public NexusNomeObjeto Componente { get; set; } = new NexusNomeObjeto();

        public NexusNomeObjeto Projeto { get; set; } = new NexusNomeObjeto();

        public string ChaveLicenca { get; set; } = "";

        public DateTime? DataVencimento { get; set; }
    }
}
