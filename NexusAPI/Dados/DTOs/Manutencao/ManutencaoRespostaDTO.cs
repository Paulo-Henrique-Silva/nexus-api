using NexusAPI.Administracao.Models;
using NexusAPI.Compartilhado.EntidadesBase.DTOs;
using NexusAPI.Compartilhado.EntidadesBase.Objetos;

namespace NexusAPI.Dados.DTOs.Manutencao
{
    public class ManutencaoRespostaDTO : NexusRespostaDTO
    {
        public NexusReferenciaObjeto Componente { get; set; } = new NexusReferenciaObjeto();

        public NexusReferenciaObjeto Projeto { get; set; } = new NexusReferenciaObjeto();

        public DateTime? DataInicio { get; set; }

        public DateTime? DataTermino { get; set; }

        public NexusReferenciaObjeto Responsavel { get; set; } = new NexusReferenciaObjeto();

        public string? Solucao { get; set; }
    }
}
