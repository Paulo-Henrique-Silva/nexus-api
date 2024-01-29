namespace NexusAPI.Compartilhado.EntidadesBase.DTOs
{
    public class NexusListaRespostaDTO
    {
        public int TotalItens { get; set; }

        public List<NexusRespostaDTO> Itens { get; set; } = new List<NexusRespostaDTO>();
    }
}
