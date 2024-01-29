using NexusAPI.Compartilhado.EntidadesBase.DTOs;

namespace NexusAPI.Dados.DTOs.Requisicao
{
    public class RequisicaoEnvioDTO : NexusEnvioDTO
    {
        public string CoordenadorUID { get; set; } = "";

        public string ProjetoUID { get; set; } = "";
    }
}
