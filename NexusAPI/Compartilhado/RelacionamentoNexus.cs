using System.ComponentModel.DataAnnotations.Schema;

namespace NexusAPI.Compartilhado
{
    public abstract class RelacionamentoNexus
    {
        [Column("ATUALIZADOPOR")]
        public string? AtualizadorPor { get; set; }

        [Column("DATAULTIMAATUALIZACAO")]
        public DateTime? DataUltimaAtualizacao { get; set; }

        [Column("USUARIOCRIADOR")]
        public string UsuarioCriador { get; set; }

        [Column("DATACRIACAO")]
        public DateTime DataCriacao { get; set; }

        [Column("FINALIZADOPOR")]
        public string? FinalizadoPor { get; set; }

        [Column("DATAFINALIZACAO")]
        public DateTime? DataFinalizacao { get; set; }

        protected RelacionamentoNexus()
        {
        }

        protected RelacionamentoNexus
        (
            string usuarioCriador
        )
        {
            UsuarioCriador = usuarioCriador;
            DataCriacao = DateTime.Now;
        }
    }
}
