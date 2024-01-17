using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using NexusAPI.Compartilhado.EntidadesBase;

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

        public CicloVida() : base() { }
    }
}
