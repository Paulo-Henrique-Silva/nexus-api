using NexusAPI.Compartilhado;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using NexusAPI.Dados.Enums;
using NexusAPI.Administracao.Models;

namespace NexusAPI.Dados.Models
{
    [Table("COMPONENTES")]
    public class Componente : ObjetoNexus
    {
        [Column("NUMEROSERIE")]
        [Required]
        public string NumeroSerie { get; set; }

        [Column("LOCALIZACAOUID")]
        [ForeignKey("Localizacao")]
        [Required]
        public string LocalizacaoUID { get; set; }

        public Localizacao? Localizacao { get; set; }

        [Column("STATUS")]
        [Required]
        public StatusComponente Status { get; set; }

        [Column("MARCA")]
        [Required]
        public string Marca { get; set; }

        [Column("MODELO")]
        [Required]
        public string Modelo { get; set; }

        [Column("TIPO")]
        [Required]
        public TipoComponente Tipo { get; set; }

        [Column("DATAAQUISICAO")]
        [Required]
        public DateTime DataAquisicao { get; set; }

        protected Componente() : base() { }

        public Componente
        (
            string nome, 
            string usuarioCriador, 
            string numeroSerie, 
            string localizacaoUID, 
            StatusComponente status, 
            string marca, 
            string modelo, 
            TipoComponente tipo, 
            DateTime dataAquisicao
        )
        : base(nome, usuarioCriador)
        {
            NumeroSerie = numeroSerie;
            LocalizacaoUID = localizacaoUID;
            Status = status;
            Marca = marca;
            Modelo = modelo;
            Tipo = tipo;
            DataAquisicao = dataAquisicao;
        }
    }
}
