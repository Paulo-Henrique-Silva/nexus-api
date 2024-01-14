using NexusAPI.Compartilhado.EntidadesBase;
using NexusAPI.Dados.Enums;

namespace NexusAPI.Dados.DTOs.Equipamento
{
    public class EquipamentoEnvioDTO : NexusEnvioDTO
    {
        public string NumeroSerie { get; set; } = "";

        public string LocalizacaoUID { get; set; } = "";

        public string ComponenteUID { get; set; } = "";

        public string Marca { get; set; } = "";

        public string Modelo { get; set; } = "";

        public TipoEquipamento Tipo { get; set; }

        public DateTime DataAquisicao { get; set; }
    }
}
