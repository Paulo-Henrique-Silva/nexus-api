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
        public string ComponenteUID { get; set; } = "";

        public Componente? Componente { get; set; }

        [Column("DATAINICIO")]
        public DateTime? DataInicio { get; set; }

        [Column("DATATERMINO")]
        public DateTime? DataTermino { get; set; }

        [Column("RESPONSAVELUID")]
        [ForeignKey("Responsavel")]
        [Required]
        public string ResponsavelUID { get; set; } = "";

        public Usuario? Responsavel { get; set; }

        [Column("SOLUCAO")]
        public string? Solucao { get; set; }

        public Manutencao() : base() { }
    }
}
