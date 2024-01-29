using NexusAPI.Compartilhado.EntidadesBase.Objetos;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NexusAPI.Administracao.Models
{
    [Table("USUARIOPERFIL")]
    public class UsuarioPerfil : NexusRelacionamento
    {
        [Column("USUARIOUID")]
        [ForeignKey("Usuario")]
        [Required]
        public string UsuarioUID { get; set; } = "";

        public Usuario? Usuario { get; set; }

        [Column("PROJETOUID")]
        [ForeignKey("Projeto")]
        [Required]
        public string ProjetoUID { get; set; } = "";

        public Projeto? Projeto { get; set; }

        [Column("PERFILUID")]
        [ForeignKey("Perfil")]
        [Required]
        public string PerfilUID { get; set; } = "";

        public Perfil? Perfil { get; set; }

        [Column("ATIVADO")]
        [Required]
        public bool Ativado { get; set; }

        public UsuarioPerfil() : base() { }
    }
}
