using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NexusAPI.Compartilhado.EntidadesBase;
using NexusAPI.Compartilhado.RespostasAPI;
using NexusAPI.Dados.DTOs.Componente;
using NexusAPI.Dados.Models;
using NexusAPI.Dados.Services;

namespace NexusAPI.Dados.Controllers
{
    [Controller]
    [Authorize]
    public class ComponenteController
    : NexusController<ComponenteEnvioDTO, ComponenteRespostaDTO, Componente>
    {
        public ComponenteController(ComponenteService service) : base(service)
        {
        }

        [HttpGet]
        public override async Task<IActionResult> Get([FromQuery] int pagina = 1)
        {
            try
            {
                var objetos = await service.ObterTudoAsync(pagina);
                return Ok(objetos);
            }
            catch (Exception)
            {
                return StatusCode(500, RespostaErroAPI.RespostaErro500);
            }
        }
    }
}
