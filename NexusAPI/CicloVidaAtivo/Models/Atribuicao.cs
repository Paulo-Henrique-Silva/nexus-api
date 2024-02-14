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
        [MaxLength(200)]
        public string UsuarioUID { get; set; } = "";

        public Usuario? Usuario { get; set; }

        [Column("TIPO")]
        [Required]
        public TipoAtribuicao Tipo { get; set; }

        [Column("OBJETOUID")]
        [Required]
        [MaxLength(200)]
        public string ObjetoUID { get; set; } = "";

        [Column("PROJETOUID")]
        [ForeignKey("Projeto")]
        [Required]
        [MaxLength(200)]
        public string ProjetoUID { get; set; } = "";

        public Projeto? Projeto { get; set; }

        [Column("DATAVENCIMENTO")]
        [Required]
        public DateTime DataVencimento { get; set; }

        [Column("CONCLUIDA")]
        [Required]
        public bool Concluida { get; set; }

        protected Atribuicao() : base() { }
    }
}
