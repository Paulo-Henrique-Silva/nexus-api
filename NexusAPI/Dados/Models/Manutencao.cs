using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using NexusAPI.Administracao.Models;
using NexusAPI.Compartilhado.EntidadesBase;

namespace NexusAPI.Dados.Models
{
    [Table("MANUTENCOES")]
    public class Manutencao : NexusObjeto
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

        [Column("DATAINICIO")]
        public DateTime? DataInicio { get; set; }

        [Column("DATATERMINO")]
        public DateTime? DataTermino { get; set; }

        [Column("RESPONSAVELUID")]
        [ForeignKey("Responsavel")]
        [Required]
        [MaxLength(200)]
        public string ResponsavelUID { get; set; } = "";

        public Usuario? Responsavel { get; set; }

        [Column("SOLUCAO")]
        [MaxLength(200)]
        public string? Solucao { get; set; }

        public Manutencao() : base() { }
    }
}
