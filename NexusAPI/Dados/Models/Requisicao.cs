using NexusAPI.Compartilhado;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using NexusAPI.Administracao.Models;

namespace NexusAPI.Dados.Models
{
    [Table("REQUISICOES")]
    public class Requisicao : ObjetoNexus
    {
        [Column("COORDENADORUID")]
        [ForeignKey("Coordenador")]
        [Required]
        public string CoordenadorUID { get; set; }

        public Usuario? Coordenador { get; set; }

        protected Requisicao() : base() { }

        public Requisicao(string coordenadorUID, string nome, string usuarioCriador) : base(nome, usuarioCriador)
        {
            CoordenadorUID = coordenadorUID;
        }
    }
}
