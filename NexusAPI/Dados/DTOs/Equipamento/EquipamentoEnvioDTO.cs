using NexusAPI.Compartilhado.EntidadesBase.DTOs;
using NexusAPI.Dados.Enums;

namespace NexusAPI.Dados.DTOs.Equipamento
{
    public class EquipamentoEnvioDTO : NexusEnvioDTO
    {
        public string NumeroSerie { get; set; } = "";

        public string ComponenteUID { get; set; } = "";

        public string ProjetoUID { get; set; } = "";

        public string Marca { get; set; } = "";

        public string Modelo { get; set; } = "";

        public TipoEquipamento Tipo { get; set; }

        public DateTime DataAquisicao { get; set; }
    }
}
