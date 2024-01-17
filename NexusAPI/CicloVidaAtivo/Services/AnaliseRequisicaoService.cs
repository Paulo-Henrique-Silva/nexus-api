using NexusAPI.CicloVidaAtivo.Repositories;
using NexusAPI.Compartilhado.Services;
using NexusAPI.Dados.Models;
using System.Runtime.Intrinsics.X86;

namespace NexusAPI.CicloVidaAtivo.Services
{
    /// <summary>
    /// Uma requisição de novo equipamento é feita por um usuário de Suporte, que indica o coordernador responsável. 
    /// O coordernador aprova ou rejeita. 
    /// Uma notificação é gerada em caso de aprovação ou rejeição. 
    /// Se aprovada, o coordenador deverá completar após o equipamento for adquirido.
    /// </summary>
    public class AnaliseRequisicaoService
    {
        private readonly AtribuicaoRepository atribuicaoRepository;

        private readonly TokenService tokenService;

        public AnaliseRequisicaoService(AtribuicaoRepository atribuicaoRepository,
            TokenService tokenService)
        {
            this.atribuicaoRepository = atribuicaoRepository;
            this.tokenService = tokenService;
        }

        public async Task IniciarCiclovida()
        {
            await AnaliseCoordenador();
        }

        public async Task AnaliseCoordenador()
        {

        }

        public async Task CoordenadorAprovou()
        {

        }

        public async Task CoordenadorReprovou()
        {

        }

        public async Task CoordenadorCompletou()
        {

        }
    }
}
