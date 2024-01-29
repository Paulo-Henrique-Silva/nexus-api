using NexusAPI.Dados.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using NexusAPI.Compartilhado.EntidadesBase.DTOs;

namespace NexusAPI.Dados.DTOs.Componente
{
    public class ComponenteEnvioDTO : NexusEnvioDTO
    {
        public string NumeroSerie { get; set; } = "";

        public string LocalizacaoUID { get; set; } = "";

        public string ProjetoUID { get; set; } = "";

        public StatusComponente Status { get; set; }

        public string Marca { get; set; } = "";

        public string Modelo { get; set; } = "";

        public TipoComponente Tipo { get; set; }

        public DateTime DataAquisicao { get; set; }
    }
}
