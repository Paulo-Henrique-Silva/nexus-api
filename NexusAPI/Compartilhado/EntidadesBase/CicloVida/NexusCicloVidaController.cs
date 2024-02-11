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
        private readonly NexusCicloVidaService nexusCicloVidaService;

        public NexusCicloVidaController(NexusCicloVidaService nexusCicloVidaService)
        {
            this.nexusCicloVidaService = nexusCicloVidaService;
        }

        [HttpPost("Iniciar")]
        public async Task<IActionResult> PostCicloVidaIniciar([FromBody] CicloVidaIniciarDTO envioDTO)
        {
            try
            {
                await nexusCicloVidaService.IniciarCiclovida(envioDTO, User.Claims);
                return Ok();
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                return StatusCode(500, RespostaErroAPI.RespostaErro500);
            }
        }
    }
}
