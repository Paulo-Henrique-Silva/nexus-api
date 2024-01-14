namespace NexusAPI.Compartilhado.EntidadesBase
{
    public class BaseObjetoRespostaDTO
    {
        public string UID { get; set; } = "";

        public string Nome { get; set; } = "";

        public string? Descricao { get; set; }

        public DateTime? DataUltimaAtualizacao { get; set; }

        public BaseNomeObjeto? AtualizadoPor { get; set; }

        public BaseNomeObjeto? UsuarioCriador { get; set; }

        public DateTime DataCriacao { get; set; }
    }
}
