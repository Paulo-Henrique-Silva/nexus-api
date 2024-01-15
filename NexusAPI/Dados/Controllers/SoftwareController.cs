using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NexusAPI.Compartilhado.EntidadesBase;
using NexusAPI.Dados.DTOs.Software;
using NexusAPI.Dados.Models;
using NexusAPI.Dados.Services;

namespace NexusAPI.Dados.Controllers
{
    [Controller]
    [Authorize]
    public class SoftwareController
    : NexusController<SoftwareEnvioDTO, SoftwareRespostaDTO, Software>
    {
        public SoftwareController(SoftwareService service) : base(service)
        {
        }
    }
}
