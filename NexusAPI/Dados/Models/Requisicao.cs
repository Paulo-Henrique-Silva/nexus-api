using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using NexusAPI.Administracao.Models;
using NexusAPI.Compartilhado.EntidadesBase;

namespace NexusAPI.Dados.Models
{
    [Table("REQUISICOES")]
    public class Requisicao : NexusObjeto
    {
        [Column("COORDENADORUID")]
        [ForeignKey("Coordenador")]
        [Required]
        public string CoordenadorUID { get; set; } = "";

        public Usuario? Coordenador { get; set; }

        [Column("PROJETOUID")]
        [ForeignKey("Projeto")]
        [Required]
        public string ProjetoUID { get; set; } = "";

        public Projeto? Projeto { get; set; }

        public Requisicao() : base() { }
    }
}
