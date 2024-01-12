using NexusAPI.Compartilhado;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NexusAPI.Administracao.Models
{
    [Table("USUARIOS")]
    public class Usuario : ObjetoNexus
    {
        [Column("NOMEACESSO")]
        [Required]
        public string NomeAcesso { get; set; }

        [Column("SENHA")]
        [Required]
        public string Senha { get; set; }

        public Usuario
        (
            string nome,
            string nomeAcesso,
            string senha,
            string usuarioCriador
        ) : base(nome, usuarioCriador)
        {
            NomeAcesso = nomeAcesso;
            Senha = senha;
        }
    }
}
