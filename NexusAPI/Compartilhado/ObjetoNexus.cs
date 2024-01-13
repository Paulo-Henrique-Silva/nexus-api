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

        [Column("ATUALIZADOPOR")]
        //[ForeignKey("Usuario")]
        public string? AtualizadorPor { get; set; }

        [Column("DATAULTIMAATUALIZACAO")]
        public DateTime? DataUltimaAtualizacao { get; set; }

        [Column("USUARIOCRIADOR")]
        [Required]
        //[ForeignKey("Usuario")]
        public string UsuarioCriador { get; set; }

        [Column("DATACRIACAO")]
        [Required]
        public DateTime DataCriacao { get; set; }

        [Column("FINALIZADOPOR")]
        //[ForeignKey("Usuario")]
        public string? FinalizadoPor { get; set; }

        [Column("DATAFINALIZACAO")]
        public DateTime? DataFinalizacao { get; set; }

        protected ObjetoNexus
        (
            string nome, 
            string usuarioCriador
        )
        {
            UID = Guid.NewGuid().ToString();
            Nome = nome;
            UsuarioCriador = usuarioCriador;
            DataCriacao = DateTime.Now;
        }
    }
}
