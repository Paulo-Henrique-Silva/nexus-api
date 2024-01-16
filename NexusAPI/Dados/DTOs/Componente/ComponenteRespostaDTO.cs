using NexusAPI.Compartilhado.EntidadesBase;
using NexusAPI.Dados.Enums;

namespace NexusAPI.Dados.DTOs.Componente
{
    public class ComponenteRespostaDTO : NexusRespostaDTO
    {
        public string NumeroSerie { get; set; } = "";

        public NexusNomeObjeto Localizacao { get; set; } = new NexusNomeObjeto();

        public NexusNomeObjeto Projeto { get; set; } = new NexusNomeObjeto();

        public StatusComponente Status { get; set; }

        public string Marca { get; set; } = "";

        public string Modelo { get; set; } = "";

        public TipoComponente Tipo { get; set; }

        public DateTime DataAquisicao { get; set; }
    }
}
