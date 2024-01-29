using NexusAPI.Administracao.Models;
using NexusAPI.Compartilhado.EntidadesBase.DTOs;

namespace NexusAPI.Dados.DTOs.Manutencao
{
    public class ManutencaoEnvioDTO : NexusEnvioDTO
    {
        public string ComponenteUID { get; set; } = "";

        public string ProjetoUID { get; set; } = "";

        public DateTime? DataInicio { get; set; }

        public DateTime? DataTermino { get; set; }

        public string ResponsavelUID { get; set; } = "";

        public string? Solucao { get; set; }
    }
}
