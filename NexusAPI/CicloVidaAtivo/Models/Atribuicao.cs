using NexusAPI.Administracao.Models;
using NexusAPI.CicloVidaAtivo.Enums;
using NexusAPI.Compartilhado.EntidadesBase;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NexusAPI.CicloVidaAtivo.Models
{
    [Table("ATRIBUICOES")]
    public class Atribuicao : NexusObjeto
    {
        [Column("USUARIOUID")]
        [ForeignKey("USUARIOFK")]
        [Required]
        public string UsuarioUID { get; set; } = "";

        public Usuario? Usuario { get; set; }

        [Column("TIPO")]
        [Required]
        public TipoAtribuicao Tipo { get; set; }

        [Column("CICLOVIDAUID")]
        [Required]
        public string CicloVidaUID { get; set; } = "";

        public CicloVida? CicloVida { get; set; }

        [Column("DATAVENCIMENTO")]
        [Required]
        public DateTime DataVencimento { get; set; }

        protected Atribuicao() : base() { }
    }
}
