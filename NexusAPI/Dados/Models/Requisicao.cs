using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using NexusAPI.Administracao.Models;
using NexusAPI.Compartilhado.EntidadesBase;

namespace NexusAPI.Dados.Models
{
    [Table("REQUISICOES")]
    public class Requisicao : BaseObjeto
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
