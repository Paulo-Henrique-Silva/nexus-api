using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using NexusAPI.Compartilhado.EntidadesBase;
using NexusAPI.CicloVidaAtivo.Enums;

namespace NexusAPI.CicloVidaAtivo.Models
{
    [Table("CICLOSVIDA")]
    public class CicloVida : NexusObjeto
    {
        //Não há propriedade de navegação para ObjetoUID, pois qualquer obj pode ser uma classe.
        [Column("OBJETOUID")]
        [Required]
        public string ObjetoUID { get; set; } = "";


        public List<CicloVidaPasso>? Passos { get; set; }

        [Column("TIPO")]
        [Required]
        public TipoCicloVida Tipo { get; set; }

        public CicloVida() : base() { }
    }
}
