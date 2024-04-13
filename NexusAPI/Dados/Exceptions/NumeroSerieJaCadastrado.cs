namespace NexusAPI.Dados.Exceptions
{
    public class NumeroSerieJaCadastrado : Exception
    {
        public NumeroSerieJaCadastrado() : base($"Nome de série já cadastrado.")
        {
        }
    }
}
