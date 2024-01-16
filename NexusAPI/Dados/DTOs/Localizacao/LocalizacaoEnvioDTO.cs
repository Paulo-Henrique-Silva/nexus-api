using NexusAPI.Compartilhado.EntidadesBase;

namespace NexusAPI.Dados.DTOs.Localizacao
{
    public class LocalizacaoEnvioDTO : NexusEnvioDTO
    {
        public string ProjetoUID { get; set; } = "";
    }
}
