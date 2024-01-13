namespace NexusAPI.Compartilhado.Exceptions
{
    public class ObjetoNaoEncontrado : Exception
    {
        public ObjetoNaoEncontrado(string UID) 
            : base($"Objeto de UID '{UID}' não foi encontrado.") { }
    }
}
