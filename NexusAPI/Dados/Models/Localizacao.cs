using NexusAPI.Administracao.Models;
using NexusAPI.Compartilhado.EntidadesBase;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NexusAPI.Dados.Models
{
    [Table("LOCALIZACOES")]
    public class Localizacao : NexusObjeto
    {
        [Column("PROJETOUID")]
        [ForeignKey("Projeto")]
        [Required]
        public string ProjetoUID { get; set; } = "";

        public Projeto? Projeto { get; set; }

        public Localizacao() : base() { }
    }
}
