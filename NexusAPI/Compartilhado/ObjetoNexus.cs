namespace NexusAPI.Compartilhado
{
    public abstract class ObjetoNexus
    {
        public string UID { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public string AtualizadorPor { get; set; }

        public DateTime DataUltimaAtualizacao { get; set; }

        public string UsuarioCriador { get; set; }

        public DateTime DataCriacao { get; set; }

        public string FinalizadoPor { get; set; }

        public DateTime DataFinalizacao { get; set; }

        protected ObjetoNexus
        (
            string nome, 
            string descricao, 
            string atualizadorPor, 
            DateTime dataUltimaAtualizacao, 
            string usuarioCriador, 
            DateTime dataCriacao, 
            string finalizadoPor, 
            DateTime dataFinalizacao
        )
        {
            UID = Guid.NewGuid().ToString();
            Nome = nome;
            Descricao = descricao;
            AtualizadorPor = atualizadorPor;
            DataUltimaAtualizacao = dataUltimaAtualizacao;
            UsuarioCriador = usuarioCriador;
            DataCriacao = dataCriacao;
            FinalizadoPor = finalizadoPor;
            DataFinalizacao = dataFinalizacao;
        }
    }
}
