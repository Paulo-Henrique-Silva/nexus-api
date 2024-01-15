using NexusAPI.CicloVida.Enums;
using NexusAPI.Compartilhado.EntidadesBase;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NexusAPI.CicloVida.DTOs.CicloVidaPasso
{
    public class CicloVidaPassoEnvioDTO : NexusEnvioDTO
    {
        public string CicloVidaUID { get; set; } = "";

        public string PassoFalhaUID { get; set; } = "";

        public string PassoSucessoUID { get; set; } = "";

        public TipoCicloVidaPasso Tipo { get; set; }
    }
}
