using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using NexusAPI.Compartilhado.EntidadesBase;

namespace NexusAPI.CicloVida.Models
{
    [Table("CICLOSVIDA")]
    public class CicloVida : BaseObjeto
    {
        [Column("OBJETOUID")]
        [Required]
        public string ObjetoUID { get; set; } = "";

        public CicloVida() : base() { }
    }
}
