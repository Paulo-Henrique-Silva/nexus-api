namespace NexusAPI.Compartilhado.RespostasAPI
{
    public class RespostaErroAPI
    {
        public int StatusCode { get; set; }

        public string Erro { get; set; }

        public static RespostaErroAPI RespostaErro500 => new(500, "Um erro inesperado aconteceu.");

        public RespostaErroAPI(int statusCode, string erro)
        {
            StatusCode = statusCode;
            Erro = erro;
        }
    }
}
