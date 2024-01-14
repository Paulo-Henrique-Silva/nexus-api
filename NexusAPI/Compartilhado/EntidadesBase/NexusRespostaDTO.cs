namespace NexusAPI.Compartilhado.EntidadesBase
{
    public class NexusRespostaDTO
    {
        public string UID { get; set; } = "";

        public string Nome { get; set; } = "";

        public string? Descricao { get; set; }

        public DateTime? DataUltimaAtualizacao { get; set; }

        public NexusNomeObjeto? AtualizadoPor { get; set; }

        public NexusNomeObjeto? UsuarioCriador { get; set; }

        public DateTime DataCriacao { get; set; }
    }
}
