using NexusAPI.Compartilhado.EntidadesBase;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NexusAPI.Administracao.Models
{
    [Table("NOTIFICACOES")]
    public class Notificacao : BaseObjeto
    {

        [ForeignKey("Usuario")]
        [Column("USUARIOUID")]
        [Required]
        public string UsuarioUID { get; set; } = "";

        public Usuario? Usuario { get; set; }

        public Notificacao() : base() { }
    }
}
