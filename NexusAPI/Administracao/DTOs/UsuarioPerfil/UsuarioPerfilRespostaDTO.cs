using NexusAPI.Compartilhado.EntidadesBase.Objetos;

namespace NexusAPI.Administracao.DTOs.UsuarioPerfil
{
    /// <summary>
    /// Resposta de UsuarioPerfil. Não herda classe de resposta por se tratar de um relacionamento e não entidade.
    /// </summary>
    public class UsuarioPerfilRespostaDTO
    {
        public NexusNomeObjeto Usuario { get; set; } = new NexusNomeObjeto();

        public NexusNomeObjeto Projeto { get; set; } = new NexusNomeObjeto();

        public NexusNomeObjeto Perfil { get; set; } = new NexusNomeObjeto();

        public bool Ativado { get; set; }

        public DateTime? DataUltimaAtualizacao { get; set; }

        public NexusNomeObjeto? AtualizadoPor { get; set; }

        public NexusNomeObjeto? UsuarioCriador { get; set; }

        public DateTime DataCriacao { get; set; }
    }
}
