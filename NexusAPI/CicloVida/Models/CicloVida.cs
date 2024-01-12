using NexusAPI.Compartilhado;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NexusAPI.CicloVida.Models
{
    [Table("CICLOSVIDA")]
    public class CicloVida : ObjetoNexus
    {
        [Column("OBJETOUID")]
        [Required]
        public string ObjetoUID { get; set; }

        public CicloVida
        (
            string nome,
            string usuarioCriador,
            string objetoUID
        )
        : base(nome, usuarioCriador)
        {
            ObjetoUID = objetoUID;
        }
    }
}
