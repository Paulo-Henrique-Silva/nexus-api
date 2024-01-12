using NexusAPI.Compartilhado;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NexusAPI.Administracao.Models
{
    [Table("USUARIOPROJETOPERFIL")]
    public class UsuarioProjetoPerfil : RelacionamentoNexus
    {
        [Column("USUARIOUID")]
        [ForeignKey("Usuario")]
        [Required]
        public string UsuarioUID { get; set; }

        [Column("PROJETOUID")]
        [ForeignKey("Projeto")]
        [Required]
        public string ProjetoUID { get; set; }

        [Column("PERFILUID")]
        [ForeignKey("Perfil")]
        [Required]
        public string PerfilUID { get; set; }

        [Column("ATIVADO")]
        [Required]
        public bool Ativado { get; set; }

        public UsuarioProjetoPerfil
        (
            string usuarioUID,
            string projetoUID,
            string perfilUID,
            bool ativado,
            string usuarioCriador
        ) 
        : base(usuarioCriador)
        {
            UsuarioUID = usuarioUID;
            ProjetoUID = projetoUID;
            PerfilUID = perfilUID;
            Ativado = ativado;
        }
    }
}
