using NexusAPI.Compartilhado.EntidadesBase.DTOs;
using NexusAPI.Compartilhado.EntidadesBase.Objetos;
using NexusAPI.Dados.Enums;

namespace NexusAPI.Dados.DTOs.Equipamento
{
    public class EquipamentoRespostaDTO : NexusRespostaDTO
    {
        public string NumeroSerie { get; set; } = "";

        public NexusReferenciaObjeto Componente { get; set; } = new NexusReferenciaObjeto();

        public NexusReferenciaObjeto Projeto { get; set; } = new NexusReferenciaObjeto();

        public string Marca { get; set; } = "";

        public string Modelo { get; set; } = "";

        public NexusReferenciaObjeto Tipo { get; set; } = new NexusReferenciaObjeto();

        public DateTime DataAquisicao { get; set; }
    }
}
