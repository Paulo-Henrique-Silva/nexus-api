using NexusAPI.Compartilhado.EntidadesBase;
using NexusAPI.Dados.Enums;

namespace NexusAPI.Dados.DTOs.Equipamento
{
    public class EquipamentoRespostaDTO : NexusRespostaDTO
    {
        public string NumeroSerie { get; set; } = "";

        public NexusNomeObjeto Localizacao { get; set; } = new NexusNomeObjeto();

        public NexusNomeObjeto Componente { get; set; } = new NexusNomeObjeto();

        public string Marca { get; set; } = "";

        public string Modelo { get; set; } = "";

        public TipoEquipamento Tipo { get; set; }

        public DateTime DataAquisicao { get; set; }
    }
}
