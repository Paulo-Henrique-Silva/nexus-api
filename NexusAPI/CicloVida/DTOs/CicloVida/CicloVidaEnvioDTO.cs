using NexusAPI.Compartilhado.EntidadesBase;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NexusAPI.CicloVida.DTOs.CicloVida
{
    public class CicloVidaEnvioDTO : NexusEnvioDTO
    {
        public string ObjetoUID { get; set; } = "";
    }
}
