using NexusAPI.CicloVidaAtivo.DTOs.CicloVida;
using NexusAPI.CicloVidaAtivo.Models;
using NexusAPI.CicloVidaAtivo.Repositories;
using NexusAPI.Compartilhado.EntidadesBase;
using NexusAPI.Compartilhado.Services;

namespace NexusAPI.CicloVidaAtivo.Services
{
    public class CicloVidaService : NexusService<CicloVidaEnvioDTO, CicloVidaRespostaDTO, CicloVida>
    {
        public CicloVidaService(CicloVidaRepository repository, TokenService tokenService) : base(repository, tokenService)
        {
        }

        public override CicloVidaRespostaDTO ConverterParaDTORespostaAsync(Models.CicloVida obj)
        {
            throw new NotImplementedException();
        }
    }
}
