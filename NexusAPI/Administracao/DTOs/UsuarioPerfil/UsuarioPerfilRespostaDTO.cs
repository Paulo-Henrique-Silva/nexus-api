using NexusAPI.Compartilhado.EntidadesBase;

namespace NexusAPI.Administracao.DTOs.UsuarioPerfil
{
    public class UsuarioPerfilRespostaDTO : NexusRespostaDTO
    {
        public NexusNomeObjeto Usuario { get; set; } = new NexusNomeObjeto();

        public NexusNomeObjeto Projeto { get; set; } = new NexusNomeObjeto();

        public NexusNomeObjeto Perfil { get; set; } = new NexusNomeObjeto();

        public bool Ativado { get; set; }
    }
}
