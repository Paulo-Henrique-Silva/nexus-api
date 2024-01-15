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

        [Column("CICLOVIDAPASSOUID")]
        [ForeignKey("CicloVidaPasso")]
        [Required]
        public string CicloVidaPassoUID { get; set; } = "";

        public CicloVidaPasso? CicloVidaPasso { get; set; }

        [Column("TIPO")]
        [Required]
        public TipoAtribuicao Tipo { get; set; }

        protected Atribuicao() : base() { }
    }
}
