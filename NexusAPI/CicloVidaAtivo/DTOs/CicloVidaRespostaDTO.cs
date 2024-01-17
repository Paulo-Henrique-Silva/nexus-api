using NexusAPI.CicloVidaAtivo.Enums;
using NexusAPI.Compartilhado.EntidadesBase;

namespace NexusAPI.CicloVidaAtivo.DTOs
{
    public class CicloVidaRespostaDTO : NexusRespostaDTO
    {
        public string ObjetoUID { get; set; } = "";

        public TipoCicloVida Tipo { get; set; }
    }
}
