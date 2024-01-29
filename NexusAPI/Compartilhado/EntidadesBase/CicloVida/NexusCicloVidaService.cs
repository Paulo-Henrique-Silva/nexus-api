using NexusAPI.CicloVidaAtivo.Repositories;
using NexusAPI.Compartilhado.Services;

namespace NexusAPI.Compartilhado.EntidadesBase.CicloVida
{
    public abstract class NexusCicloVidaService
    {
        protected readonly AtribuicaoRepository atribuicaoRepository;

        protected readonly CicloVidaRepository cicloVidaRepository;

        protected readonly TokenService tokenService;

        protected NexusCicloVidaService(AtribuicaoRepository atribuicaoRepository,
            CicloVidaRepository cicloVidaRepository, TokenService tokenService)
        {
            this.atribuicaoRepository = atribuicaoRepository;
            this.cicloVidaRepository = cicloVidaRepository;
            this.tokenService = tokenService;
        }

        public abstract Task IniciarCiclovida();
    }
}
