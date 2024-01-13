using NexusAPI.Compartilhado;
using NexusAPI.Dados.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NexusAPI.Dados.Models
{
    [Table("EQUIPAMENTOS")]
    public class Equipamento : ObjetoNexus
    {
        [Column("NUMEROSERIE")]
        [Required]
        public string NumeroSerie { get; set; }

        [Column("LOCALIZACAOUID")]
        [ForeignKey("Localizacao")]
        [Required]
        public string LocalizacaoUID { get; set; }

        public Localizacao? Localizacao { get; set; }

        [Column("COMPONENTEUID")]
        [ForeignKey("Componente")]
        [Required]
        public string ComponenteUID { get; set; }

        public Componente? Componente { get; set; }

        [Column("MARCA")]
        [Required]
        public string Marca { get; set; }

        [Column("MODELO")]
        [Required]
        public string Modelo { get; set; }

        [Column("TIPO")]
        [Required]
        public TipoEquipamento Tipo { get; set; }

        [Column("DATAAQUISICAO")]
        [Required]
        public DateTime DataAquisicao { get; set; }

        protected Equipamento() : base() { }

        public Equipamento
        (
            string nome,
            string usuarioCriador,
            string numeroSerie,
            string localizacaoUID,
            string componenteUID,
            string marca,
            string modelo,
            TipoEquipamento tipo,
            DateTime dataAquisicao
        )
        : base(nome, usuarioCriador)
        {
            NumeroSerie = numeroSerie;
            ComponenteUID = componenteUID;
            LocalizacaoUID = localizacaoUID;
            Marca = marca;
            Modelo = modelo;
            Tipo = tipo;
            DataAquisicao = dataAquisicao;
        }
    }
}
