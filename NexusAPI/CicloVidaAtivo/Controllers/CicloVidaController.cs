using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NexusAPI.CicloVidaAtivo.DTOs.CicloVida;
using NexusAPI.CicloVidaAtivo.Models;
using NexusAPI.CicloVidaAtivo.Services;
using NexusAPI.Compartilhado.EntidadesBase;

namespace NexusAPI.CicloVidaAtivo.Controllers
{
    [Controller]
    [Authorize]
    public class CicloVidaController
    : NexusController<CicloVidaEnvioDTO, CicloVidaRespostaDTO, CicloVida>
    {
        public CicloVidaController(CicloVidaService service) : base(service)
        {
        }
    }
}
