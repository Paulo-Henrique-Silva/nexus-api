using NexusAPI.Compartilhado.EntidadesBase;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using NexusAPI.CicloVidaAtivo.Enums;

namespace NexusAPI.CicloVidaAtivo.DTOs
{
    public class CicloVidaEnvioDTO : NexusEnvioDTO
    {
        public string ObjetoUID { get; set; } = "";

        public TipoCicloVida Tipo { get; set; }
    }
}
