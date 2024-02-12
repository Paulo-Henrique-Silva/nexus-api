using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NexusAPI.CicloVidaAtivo.DTOs.CicloVida;
using NexusAPI.CicloVidaAtivo.Services;
using NexusAPI.Compartilhado.RespostasAPI;

namespace NexusAPI.Compartilhado.EntidadesBase.CicloVida
{
    [Authorize]
    [Route("api/CicloVida/[controller]")]
    public class NexusCicloVidaController : ControllerBase
    {
        protected readonly NexusCicloVidaService service;

        public NexusCicloVidaController(NexusCicloVidaService nexusCicloVidaService)
        {
            this.service = nexusCicloVidaService;
        }

        [HttpPost("Iniciar")]
        public async Task<IActionResult> PostCicloVidaIniciar([FromBody] CicloVidaIniciarDTO envioDTO)
        {
            try
            {
                await service.IniciarCiclovida(envioDTO, User.Claims);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500, RespostaErroAPI.RespostaErro500);
            }
        }
    }
}
