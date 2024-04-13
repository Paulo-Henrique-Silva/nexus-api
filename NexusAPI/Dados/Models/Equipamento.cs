using NexusAPI.Dados.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using NexusAPI.Compartilhado.EntidadesBase;
using NexusAPI.Administracao.Models;

namespace NexusAPI.Dados.Models
{
    [Table("EQUIPAMENTOS")]
    public class Equipamento : NexusObjeto
    {
        [Column("NUMEROSERIE")]
        [Required]
        [MaxLength(200)]
        public string NumeroSerie { get; set; } = "";

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

        [Column("MARCA")]
        [Required]
        [MaxLength(200)]
        public string Marca { get; set; } = "";

        [Column("MODELO")]
        [Required]
        [MaxLength(200)]
        public string Modelo { get; set; } = "";

        [Column("TIPO")]
        [Required]
        public TipoEquipamento Tipo { get; set; }

        [Column("DATAAQUISICAO")]
        [Required]
        public DateTime DataAquisicao { get; set; }

        public Equipamento() : base() { }
    }
}
