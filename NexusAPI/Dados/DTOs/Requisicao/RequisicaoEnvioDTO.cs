using NexusAPI.Compartilhado.EntidadesBase;

namespace NexusAPI.Dados.DTOs.Requisicao
{
    public class RequisicaoEnvioDTO : NexusEnvioDTO
    {
        public string CoordenadorUID { get; set; } = "";

        public string ProjetoUID { get; set; } = "";
    }
}
