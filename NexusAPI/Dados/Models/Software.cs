using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using NexusAPI.Compartilhado.EntidadesBase;
using NexusAPI.Administracao.Models;

namespace NexusAPI.Dados.Models
{
    [Table("SOFTWARES")]
    public class Software : NexusObjeto
    {
        [Column("COMPONENTEUID")]
        [ForeignKey("Componente")]
        [Required]
        [MaxLength(200)]
        public string ComponenteUID { get; set; } = "";

        public Componente? Componente { get; set; }

        [Column("PROJETOUID")]
        [ForeignKey("Projeto")]
        [Required]
        [MaxLength(200)]
        public string ProjetoUID { get; set; } = "";

        public Projeto? Projeto { get; set; }

        [Column("CHAVELICENCA")]
        [Required]
        [MaxLength(200)]
        public string ChaveLicenca { get; set; } = "";

        [Column("DATAVENCIMENTO")]
        public DateTime? DataVencimento { get; set; }

        public Software() : base() { }
    }
}
