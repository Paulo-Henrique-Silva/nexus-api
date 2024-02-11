using NexusAPI.CicloVidaAtivo.DTOs.CicloVida;
using NexusAPI.CicloVidaAtivo.Repositories;
using NexusAPI.CicloVidaAtivo.Services;
using NexusAPI.Compartilhado.Services;
using System.Security.Claims;

namespace NexusAPI.Compartilhado.EntidadesBase.CicloVida
{
    public abstract class NexusCicloVidaService
    {
        protected readonly AtribuicaoService atribuicaoService;

        protected readonly CicloVidaRepository cicloVidaRepository;

        protected readonly TokenService tokenService;

        protected NexusCicloVidaService(AtribuicaoService atribuicaoService,
            CicloVidaRepository cicloVidaRepository, TokenService tokenService)
        {
            this.atribuicaoService = atribuicaoService;
            this.cicloVidaRepository = cicloVidaRepository;
            this.tokenService = tokenService;
        }

        public abstract Task IniciarCiclovida(CicloVidaIniciarDTO envioDTO, IEnumerable<Claim> claims);
    }
}
