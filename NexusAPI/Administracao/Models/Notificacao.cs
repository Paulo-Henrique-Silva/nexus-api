using NexusAPI.Compartilhado;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NexusAPI.Administracao.Models
{
    [Table("NOTIFICACOES")]
    public class Notificacao : ObjetoNexus
    {

        [ForeignKey("Usuario")]
        [Column("USUARIOUID")]
        [Required]
        public string UsuarioUID { get; set; }

        public Usuario? Usuario { get; set; }

        protected Notificacao() : base() { }

        public Notificacao(string nome, string usuarioCriador, string usuarioUID)
        : base(nome, usuarioCriador)
        {
            UsuarioUID = usuarioUID;
        }
    }
}
