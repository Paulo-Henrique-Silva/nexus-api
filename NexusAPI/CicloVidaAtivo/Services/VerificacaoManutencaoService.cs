using NexusAPI.Administracao.Models;
using NexusAPI.CicloVidaAtivo.Repositories;
using NexusAPI.Compartilhado.EntidadesBase;
using NexusAPI.Compartilhado.Services;

namespace NexusAPI.CicloVidaAtivo.Services
{
    /// <summary>
    /// Um coordernador ou administrador pode criar manutenções. As manutenções podem ser atribuídas para 
    /// o próprio usuário ou para outro. O usuário atribuído deverá marcar a manuteção concluída, depois que preencher
    /// o campo de solução.
    /// </summary>
    public class VerificacaoManutencaoService : NexusCicloVidaService
    {
        public VerificacaoManutencaoService(AtribuicaoRepository atribuicaoRepository, 
            CicloVidaRepository cicloVidaRepository, TokenService tokenService) 
        : base(atribuicaoRepository, cicloVidaRepository, tokenService)
        {
        }

        public override async Task IniciarCiclovida()
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
