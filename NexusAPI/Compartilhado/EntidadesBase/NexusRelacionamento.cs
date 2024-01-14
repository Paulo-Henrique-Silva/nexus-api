using System.ComponentModel.DataAnnotations.Schema;

namespace NexusAPI.Compartilhado.EntidadesBase
{
    public abstract class NexusRelacionamento
    {
        [Column("ATUALIZADOPORUID")]
        public string? AtualizadoPorUID { get; set; }

        [Column("DATAULTIMAATUALIZACAO")]
        public DateTime? DataUltimaAtualizacao { get; set; }

        [Column("USUARIOCRIADORUID")]
        public string? UsuarioCriadorUID { get; set; }

        [Column("DATACRIACAO")]
        public DateTime DataCriacao { get; set; }

        [Column("FINALIZADOPORUID")]
        public string? FinalizadoPorUID { get; set; }

        [Column("DATAFINALIZACAO")]
        public DateTime? DataFinalizacao { get; set; }

        protected NexusRelacionamento()
        {
        }
    }
}
