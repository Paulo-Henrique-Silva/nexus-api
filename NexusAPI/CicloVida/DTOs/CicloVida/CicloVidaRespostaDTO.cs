using NexusAPI.Compartilhado.EntidadesBase;

namespace NexusAPI.CicloVida.DTOs.CicloVida
{
    public class CicloVidaRespostaDTO : NexusRespostaDTO
    {
        public NexusNomeObjeto Objeto { get; set; } = new NexusNomeObjeto();
    }
}
