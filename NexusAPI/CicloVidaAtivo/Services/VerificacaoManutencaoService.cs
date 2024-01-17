using NexusAPI.Administracao.Models;

namespace NexusAPI.CicloVidaAtivo.Services
{
    /// <summary>
    /// Um coordernador ou administrador pode criar manutenções. As manutenções podem ser atribuídas para 
    /// o próprio usuário ou para outro. O usuário atribuído deverá marcar a manuteção concluída, depois que preencher
    /// o campo de solução.
    /// </summary>
    public class VerificacaoManutencaoService
    {
        public async Task IniciarCiclovida()
        {
            await CriacaoManutencao();
        }

        public async Task CriacaoManutencao()
        {

        }

        public async Task UsuarioConcluiu()
        {

        }
    }
}
