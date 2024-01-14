using NexusAPI.Administracao.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace NexusAPI.Compartilhado.EntidadesBase
{
    public abstract class NexusRelacionamento
    {
        [Column("ATUALIZADOPORUID")]
        [ForeignKey("AtualizadoPor")]
        public string? AtualizadoPorUID { get; set; }

        public Usuario? AtualizadoPor { get; set; }

        [Column("DATAULTIMAATUALIZACAO")]
        public DateTime? DataUltimaAtualizacao { get; set; }

        [Column("USUARIOCRIADORUID")]
        [ForeignKey("UsuarioCriador")]
        public string? UsuarioCriadorUID { get; set; }

        public Usuario? UsuarioCriador { get; set; }

        [Column("DATACRIACAO")]
        public DateTime DataCriacao { get; set; }

        [Column("FINALIZADOPORUID")]
        [ForeignKey("FinalizadoPor")]
        public string? FinalizadoPorUID { get; set; }

        public Usuario? FinalizadoPor { get; set; }

        [Column("DATAFINALIZACAO")]
        public DateTime? DataFinalizacao { get; set; }

        protected NexusRelacionamento()
        {
        }
    }
}
