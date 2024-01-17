using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using NexusAPI.CicloVidaAtivo.Enums;
using NexusAPI.Administracao.Models;
using NexusAPI.Compartilhado.EntidadesBase;

namespace NexusAPI.CicloVidaAtivo.Models
{
    [Table("CICLOVIDAPASSOS")]
    public class CicloVidaPasso : NexusObjeto
    {
        [Column("CICLOVIDAUID")]
        [ForeignKey("CicloVida")]
        [Required]
        public string CicloVidaUID { get; set; } = "";

        public CicloVida? CicloVida { get; set; }

        [Column("PASSOFALHAUID")]
        public string? PassoFalhaUID { get; set; }

        public CicloVidaPasso? PassoFalha { get; set; }

        [Column("PASSOSUCESSOUID")]
        public string? PassoSucessoUID { get; set; }

        public CicloVidaPasso? PassoSucesso { get; set; }

        [Column("METODO")]
        public string? Metodo { get; set; }

        public CicloVidaPasso() : base() { }
    }
}
