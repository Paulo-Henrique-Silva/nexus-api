using NexusAPI.CicloVida.Models;
using NexusAPI.Compartilhado.EntidadesBase;
using NexusAPI.Dados.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NexusAPI.Administracao.Models
{
    [Table("USUARIOS")]
    public class Usuario : BaseObjeto
    {
        [Column("NOMEACESSO")]
        [Required]
        public string NomeAcesso { get; set; } = "";

        [Column("SENHA")]
        [Required]
        public string Senha { get; set; } = "";

        public Usuario() : base() { }
    }
}
