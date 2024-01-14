using NexusAPI.Compartilhado.EntidadesBase;

namespace NexusAPI.Administracao.DTOs.UsuarioProjetoPerfil
{
    public class UsuarioProjetoPerfilRespostaDTO : NexusRespostaDTO
    {
        public string UsuarioUID { get; set; } = "";

        public string ProjetoUID { get; set; } = "";

        public string PerfilUID { get; set; } = "";

        public bool Ativado { get; set; }
    }
}
