using NexusAPI.Compartilhado.EntidadesBase;

namespace NexusAPI.Dados.DTOs.Localizacao
{
    public class LocalizacaoRespostaDTO : NexusRespostaDTO
    {
        public NexusNomeObjeto Projeto { get; set; } = new NexusNomeObjeto();
    }
}
