using NexusAPI.Administracao.Models;
using NexusAPI.Compartilhado.EntidadesBase;

namespace NexusAPI.Dados.DTOs.Manutencao
{
    public class ManutencaoRespostaDTO : NexusRespostaDTO
    {
        public NexusNomeObjeto Componente { get; set; } = new NexusNomeObjeto();

        public NexusNomeObjeto Projeto { get; set; } = new NexusNomeObjeto();

        public DateTime? DataInicio { get; set; }

        public DateTime? DataTermino { get; set; }

        public NexusNomeObjeto Responsavel { get; set; } = new NexusNomeObjeto();

        public string? Solucao { get; set; }
    }
}
