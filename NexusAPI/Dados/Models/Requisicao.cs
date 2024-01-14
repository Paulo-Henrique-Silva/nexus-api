using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using NexusAPI.Administracao.Models;
using NexusAPI.Compartilhado.EntidadesBase;

namespace NexusAPI.Dados.Models
{
    [Table("REQUISICOES")]
    public class Requisicao : NexusObjeto
    {
        [Column("COORDENADORUID")]
        [ForeignKey("Coordenador")]
        [Required]
        public string CoordenadorUID { get; set; } = "";

        public Usuario? Coordenador { get; set; }

        public Requisicao() : base() { }
    }
}
