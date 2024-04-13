using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using NexusAPI.Dados.Enums;
using NexusAPI.Administracao.Models;
using NexusAPI.Compartilhado.EntidadesBase;

namespace NexusAPI.Dados.Models
{
    [Table("COMPONENTES")]
    public class Componente : NexusObjeto
    {
        [Column("NUMEROSERIE")]
        [Required]
        [MaxLength(200)]
        public string NumeroSerie { get; set; } = "";

        [Column("LOCALIZACAOUID")]
        [ForeignKey("Localizacao")]
        [Required]
        [MaxLength(200)]
        public string LocalizacaoUID { get; set; } = "";

        public Localizacao? Localizacao { get; set; }

        [Column("STATUS")]
        [Required]
        public StatusComponente Status { get; set; }

        [Column("MARCA")]
        [Required]
        [MaxLength(200)]
        public string Marca { get; set; } = "";

        [Column("MODELO")]
        [Required]
        [MaxLength(200)]
        public string Modelo { get; set; } = "";

        [Column("PROJETOUID")]
        [ForeignKey("Projeto")]
        [Required]
        [MaxLength(200)]
        public string ProjetoUID { get; set; } = "";

        public Projeto? Projeto { get; set; }

        [Column("TIPO")]
        [Required]
        public TipoComponente Tipo { get; set; }

        [Column("DATAAQUISICAO")]
        [Required]
        public DateTime DataAquisicao { get; set; }

        [Column("LINKNOTAFISCAL")]
        [Required]
        [MaxLength(200)]
        public string LinkNotaFiscal { get; set; } = "";

        public Componente() : base() { }
    }
}
