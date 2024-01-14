namespace NexusAPI.Administracao.Exceptions
{
    public class CredenciaisIncorretas : Exception
    {
        public CredenciaisIncorretas() : base($"Credenciais incorretas.")
        {
        }
    }
}
