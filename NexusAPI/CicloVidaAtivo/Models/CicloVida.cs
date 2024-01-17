using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using NexusAPI.Compartilhado.EntidadesBase;
using NexusAPI.CicloVidaAtivo.Enums;

namespace NexusAPI.CicloVidaAtivo.Models
{
    [Table("CICLOSVIDA")]
    public class CicloVida
    {
        [Key]
        [Column("UID")]
        public string UID { get; set; } = "";

        //Não há propriedade de navegação para ObjetoUID, pois qualquer obj pode ser uma classe.
        [Column("OBJETOUID")]
        [Required]
        public string ObjetoUID { get; set; } = "";

        [Column("FINALIZADO")]
        [Required]
        public bool Finalizado { get; set; }

        public CicloVida() { }
    }
}
