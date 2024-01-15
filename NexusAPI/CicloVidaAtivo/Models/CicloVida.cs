using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using NexusAPI.Compartilhado.EntidadesBase;

namespace NexusAPI.CicloVidaAtivo.Models
{
    [Table("CICLOSVIDA")]
    public class CicloVida : NexusObjeto
    {
        [Column("OBJETOUID")]
        [Required]
        public string ObjetoUID { get; set; } = "";

        public CicloVida() : base() { }
    }
}
