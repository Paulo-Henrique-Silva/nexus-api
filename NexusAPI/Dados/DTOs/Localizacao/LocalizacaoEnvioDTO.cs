using NexusAPI.Compartilhado.EntidadesBase.DTOs;

namespace NexusAPI.Dados.DTOs.Localizacao
{
    public class LocalizacaoEnvioDTO : NexusEnvioDTO
    {
        public string ProjetoUID { get; set; } = "";
    }
}
