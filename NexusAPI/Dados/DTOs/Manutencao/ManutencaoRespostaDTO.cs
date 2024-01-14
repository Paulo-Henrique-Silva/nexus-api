using NexusAPI.Administracao.Models;
using NexusAPI.Compartilhado.EntidadesBase;

namespace NexusAPI.Dados.DTOs.Manutencao
{
    public class ManutencaoRespostaDTO
    {
        public NexusNomeObjeto Componente { get; set; } = new NexusNomeObjeto();

        public DateTime? DataInicio { get; set; }

        public DateTime? DataTermino { get; set; }

        public string ResponsavelUID { get; set; } = "";

        public Usuario? Responsavel { get; set; }

        public string? Solucao { get; set; }
    }
}
