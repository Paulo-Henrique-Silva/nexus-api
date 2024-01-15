using NexusAPI.CicloVidaAtivo.Enums;
using NexusAPI.Compartilhado.EntidadesBase;

namespace NexusAPI.CicloVidaAtivo.DTOs.Atribuicao
{
    public class AtribuicaoRespostaDTO : NexusRespostaDTO
    {
        public NexusNomeObjeto Usuario { get; set; } = new NexusNomeObjeto();

        public NexusNomeObjeto CicloVidaPasso { get; set; } = new NexusNomeObjeto();

        public TipoAtribuicao Tipo { get; set; }
    }
}
