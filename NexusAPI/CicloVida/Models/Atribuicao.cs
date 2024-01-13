using NexusAPI.Administracao.Models;
using NexusAPI.CicloVida.Enums;
using NexusAPI.Compartilhado.EntidadesBase;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NexusAPI.CicloVida.Models
{
    [Table("ATRIBUICOES")]
    public class Atribuicao : BaseObjeto
    {
        [Column("USUARIOUID")]
        [ForeignKey("USUARIOFK")]
        [Required]
        public string UsuarioUID { get; set; }

        public Usuario? Usuario { get; set; }

        [Column("CICLOVIDAPASSOUID")]
        [ForeignKey("CicloVidaPasso")]
        [Required]
        public string CicloVidaPassoUID { get; set; }

        public CicloVidaPasso? CicloVidaPasso { get; set; }

        [Column("TIPO")]
        [Required]
        public TipoAtribuicao Tipo { get; set; }

        protected Atribuicao() : base() { }

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
