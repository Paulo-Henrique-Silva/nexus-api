namespace NexusAPI.Compartilhado.EntidadesBase
{
    public class BaseRespostaDTO
    {
        public string UID { get; set; } = "";

        public string Nome { get; set; } = "";

        public string? Descricao { get; set; }

        public DateTime? DataUltimaAtualizacao { get; set; }

        public BaseObjetoResposta? AtualizadoPor { get; set; }

        public BaseObjetoResposta? UsuarioCriador { get; set; }

        public DateTime DataCriacao { get; set; }
    }
}
