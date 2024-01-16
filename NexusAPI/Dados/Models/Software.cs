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
        public string ComponenteUID { get; set; } = "";

        public Componente? Componente { get; set; }

        [Column("PROJETOUID")]
        [ForeignKey("Projeto")]
        [Required]
        public string ProjetoUID { get; set; } = "";

        public Projeto? Projeto { get; set; }

        [Column("CHAVELICENCA")]
        [Required]
        public string ChaveLicenca { get; set; } = "";

        [Column("DATAVENCIMENTO")]
        public DateTime? DataVencimento { get; set; }

        public Software() : base() { }
    }
}
