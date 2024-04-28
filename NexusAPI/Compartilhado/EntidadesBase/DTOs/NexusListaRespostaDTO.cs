namespace NexusAPI.Compartilhado.EntidadesBase.DTOs
{
    /// <summary>
    /// DTO para retornar listas de objetos. Evitando sobrecarregamento de dados.
    /// </summary>
    /// <typeparam name="O">DTO de resposta</typeparam>
    public class NexusListaRespostaDTO<O>
    {
        public int TotalItens { get; set; }

        public List<O> Itens { get; set; } = new List<O>();
    }
}
