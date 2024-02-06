using NexusAPI.Compartilhado.EntidadesBase.Objetos;

namespace NexusAPI.Administracao.DTOs.UsuarioPerfil
{
    /// <summary>
    /// Resposta de UsuarioPerfil. Não herda classe de resposta por se tratar de um relacionamento e não entidade.
    /// </summary>
    public class UsuarioPerfilRespostaDTO
    {
        public NexusReferenciaObjeto Usuario { get; set; } = new NexusReferenciaObjeto();

        public NexusReferenciaObjeto Projeto { get; set; } = new NexusReferenciaObjeto();

        public NexusReferenciaObjeto Perfil { get; set; } = new NexusReferenciaObjeto();

        public bool Ativado { get; set; }

        public DateTime? DataUltimaAtualizacao { get; set; }

        public NexusReferenciaObjeto? AtualizadoPor { get; set; }

        public NexusReferenciaObjeto? UsuarioCriador { get; set; }

        public DateTime DataCriacao { get; set; }
    }
}
