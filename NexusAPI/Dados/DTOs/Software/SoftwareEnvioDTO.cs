using NexusAPI.Compartilhado.EntidadesBase.DTOs;

namespace NexusAPI.Dados.DTOs.Software
{
    public class SoftwareEnvioDTO : NexusEnvioDTO
    {
        public string ComponenteUID { get; set; } = "";

        public string ChaveLicenca { get; set; } = "";

        public string ProjetoUID { get; set; } = "";

        public DateTime? DataVencimento { get; set; }
    }
}
