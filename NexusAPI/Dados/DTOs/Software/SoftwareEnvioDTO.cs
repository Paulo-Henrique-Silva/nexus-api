using NexusAPI.Compartilhado.EntidadesBase;

namespace NexusAPI.Dados.DTOs.Software
{
    public class SoftwareEnvioDTO : NexusEnvioDTO
    {
        public string LocalizacaoUID { get; set; } = "";

        public string ComponenteUID { get; set; } = "";

        public string ChaveLicenca { get; set; } = "";

        public DateTime? DataVencimento { get; set; }
    }
}
