using NexusAPI.CicloVida.Enums;
using NexusAPI.Compartilhado;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NexusAPI.CicloVida.Models
{
    [Table("ATRIBUICAO")]
    public class Atribuicao : ObjetoNexus
    {
        [Column("USUARIOUID")]
        [ForeignKey("Usuario")]
        [Required]
        public string UsuarioUID { get; set; }

        [Column("CICLOVIDAPASSOUID")]
        [ForeignKey("CicloVidaPasso")]
        [Required]
        public string CicloVidaPassoUID { get; set; }

        [Column("TIPO")]
        [Required]
        public TipoAtribuicao Tipo { get; set; }

        public Atribuicao
        (
            string nome, 
            string usuarioCriador, 
            string usuarioUID, 
            string cicloVidaPassoUID, 
            TipoAtribuicao tipo
        ) 
        : base(nome, usuarioCriador)
        {
            UsuarioUID = usuarioUID;
            CicloVidaPassoUID = cicloVidaPassoUID;
            Tipo = tipo;
        }
    }
}
