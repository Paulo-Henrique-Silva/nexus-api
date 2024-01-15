using NexusAPI.CicloVidaAtivo.Enums;
using NexusAPI.Compartilhado.EntidadesBase;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NexusAPI.CicloVidaAtivo.DTOs.CicloVidaPasso
{
    public class CicloVidaPassoEnvioDTO : NexusEnvioDTO
    {
        public string CicloVidaUID { get; set; } = "";

        public string PassoFalhaUID { get; set; } = "";

        public string PassoSucessoUID { get; set; } = "";

        public TipoCicloVidaPasso Tipo { get; set; }
    }
}
