using NexusAPI.CicloVidaAtivo.Models;
using NexusAPI.Compartilhado.EntidadesBase;
using NexusAPI.Dados.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NexusAPI.Administracao.Models
{
    [Table("USUARIOS")]
    public class Usuario : NexusObjeto
    {
        [Column("NOMEACESSO")]
        [Required]
        [MaxLength(200)]
        public string NomeAcesso { get; set; } = "";

        [Column("SENHA")]
        [Required]
        [MaxLength(200)]
        public string Senha { get; set; } = "";

        public Usuario() : base() { }
    }
}
