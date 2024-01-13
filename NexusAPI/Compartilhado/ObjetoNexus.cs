using NexusAPI.Administracao.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NexusAPI.Compartilhado
{
    public abstract class ObjetoNexus
    {
        [Key]
        [Column("UID")]
        public string UID { get; set; }

        [Column("NOME")]
        [Required]
        public string Nome { get; set; }

        [Column("DESCRICAO")]
        public string? Descricao { get; set; }

        [Column("ATUALIZADOPORUID")]
        [ForeignKey("AtualizadoPor")]
        public string? AtualizadoPorUID { get; set; }

        public Usuario? AtualizadoPor { get; set; }

        [Column("DATAULTIMAATUALIZACAO")]
        public DateTime? DataUltimaAtualizacao { get; set; }

        [Column("USUARIOCRIADORUID")]
        [Required]
        [ForeignKey("UsuarioCriador")]
        public string UsuarioCriadorUID { get; set; }

        public Usuario? UsuarioCriador { get; set; }

        [Column("DATACRIACAO")]
        [Required]
        public DateTime DataCriacao { get; set; }

        [Column("FINALIZADOPORUID")]
        [ForeignKey("FinalizadoPor")]
        public string? FinalizadoPorUID { get; set; }

        public Usuario? FinalizadoPor { get; set; }

        [Column("DATAFINALIZACAO")]
        public DateTime? DataFinalizacao { get; set; }

        protected ObjetoNexus() { }

        protected ObjetoNexus
        (
            string nome, 
            string usuarioCriador
        )
        {
            UID = Guid.NewGuid().ToString();
            Nome = nome;
            UsuarioCriadorUID = usuarioCriador;
            DataCriacao = DateTime.Now;
        }
    }
}
