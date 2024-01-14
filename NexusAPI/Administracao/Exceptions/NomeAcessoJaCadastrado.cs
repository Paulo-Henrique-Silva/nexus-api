namespace NexusAPI.Administracao.Exceptions
{
    public class NomeAcessoJaCadastrado : Exception
    {
        public NomeAcessoJaCadastrado() : base($"Nome de acesso já cadastrado.")
        {
        }
    }
}
