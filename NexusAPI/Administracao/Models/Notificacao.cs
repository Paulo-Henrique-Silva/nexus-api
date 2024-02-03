using NexusAPI.Compartilhado.EntidadesBase;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NexusAPI.Administracao.Models
{
    [Table("NOTIFICACOES")]
    public class Notificacao : NexusObjeto
    {

        [ForeignKey("Usuario")]
        [Column("USUARIOUID")]
        [Required]
        [MaxLength(200)]
        public string UsuarioUID { get; set; } = "";

        public Usuario? Usuario { get; set; }

        /// <summary>
        /// Se a notificação foi visualizada pelo usuário.
        /// </summary>
        [Column("VISTA")]
        [Required]
        public bool Vista { get; set; }

        public Notificacao() : base() { }
    }
}
