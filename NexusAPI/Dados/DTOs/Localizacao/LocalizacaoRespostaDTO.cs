using NexusAPI.Compartilhado.EntidadesBase.DTOs;
using NexusAPI.Compartilhado.EntidadesBase.Objetos;

namespace NexusAPI.Dados.DTOs.Localizacao
{
    public class LocalizacaoRespostaDTO : NexusRespostaDTO
    {
        public NexusNomeObjeto Projeto { get; set; } = new NexusNomeObjeto();
    }
}
