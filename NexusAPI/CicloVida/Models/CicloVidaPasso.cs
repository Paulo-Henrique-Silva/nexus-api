using NexusAPI.Compartilhado;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using NexusAPI.CicloVida.Enums;
using NexusAPI.Administracao.Models;

namespace NexusAPI.CicloVida.Models
{
    [Table("CICLOVIDAPASSOS")]
    public class CicloVidaPasso : ObjetoNexus
    {
        [Column("CICLOVIDAUID")]
        [ForeignKey("CicloVida")]
        [Required]
        public string CicloVidaUID { get; set; }

        public CicloVida? CicloVida { get; set; }

        [Column("PASSOFALHAUID")]
        [ForeignKey("PassoFalha")]
        [Required]
        public string PassoFalhaUID { get; set; }

        public CicloVidaPasso? PassoFalha { get; set; }

        [Column("PASSOSUCESSOUID")]
        [ForeignKey("PassoSucesso")]
        [Required]
        public string PassoSucessoUID { get; set; }

        public CicloVidaPasso? PassoSucesso { get; set; }

        [Column("TIPO")]
        [Required]
        public TipoCicloVidaPasso Tipo { get; set; }

        public CicloVidaPasso
        (
            string nome,
            string cicloVidaUID,
            string passoFalhaUID,
            string passoSucessoUID,
            TipoCicloVidaPasso tipo,
            string usuarioCriador
        ) : base(nome, usuarioCriador)
        {
            CicloVidaUID = cicloVidaUID;
            PassoFalhaUID = passoFalhaUID;
            PassoSucessoUID = passoSucessoUID;
            Tipo = tipo;
        }
    }
}
