using NexusAPI.CicloVidaAtivo.Repositories;
using NexusAPI.Compartilhado.Services;

namespace NexusAPI.CicloVidaAtivo.Services
{
    public class AnaliseRequisicaoService
    {
        private readonly CicloVidaRepository cicloVidaRepository;

        private readonly CicloVidaPassoRepository cicloVidaPassoRepository;

        private readonly AtribuicaoRepository atribuicaoRepository;

        private readonly TokenService tokenService;

        public AnaliseRequisicaoService(CicloVidaRepository cicloVidaRepository,
            CicloVidaPassoRepository cicloVidaPassoRepository, AtribuicaoRepository atribuicaoRepository,
            TokenService tokenService)
        {
            this.cicloVidaRepository = cicloVidaRepository;
            this.cicloVidaPassoRepository = cicloVidaPassoRepository;
            this.atribuicaoRepository = atribuicaoRepository;
            this.tokenService = tokenService;
        }

        public void IniciarCiclovida()
        {

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
