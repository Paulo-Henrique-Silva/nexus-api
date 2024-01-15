using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NexusAPI.CicloVidaAtivo.DTOs.CicloVidaPasso;
using NexusAPI.CicloVidaAtivo.Models;
using NexusAPI.CicloVidaAtivo.Services;
using NexusAPI.Compartilhado.EntidadesBase;

namespace NexusAPI.CicloVidaAtivo.Controllers
{
    [Controller]
    [Authorize]
    public class CicloVidaPassoController
    : NexusController<CicloVidaPassoEnvioDTO, CicloVidaPassoRespostaDTO, CicloVidaPasso>
    {
        public CicloVidaPassoController(CicloVidaPassoService service) : base(service)
        {
        }
    }
}
