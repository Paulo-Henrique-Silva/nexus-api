using NexusAPI.Compartilhado;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NexusAPI.Administracao.Models
{
    [Table("NOTIFICACAO")]
    public class Notificacao : ObjetoNexus
    {
        [Column("USUARIOUID")]
        [ForeignKey("Usuario")]
        [Required]
        public string UsuarioUID { get; set; }

        public Notificacao
        (
            string nome, 
            string usuarioCriador, 
            string usuarioUID
        ) 
        : base(nome, usuarioCriador)
        {
            UsuarioUID = usuarioUID;
        }
    }
}
