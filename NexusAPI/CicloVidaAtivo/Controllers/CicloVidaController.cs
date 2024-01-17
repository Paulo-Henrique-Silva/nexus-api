using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NexusAPI.CicloVidaAtivo.DTOs;
using NexusAPI.CicloVidaAtivo.Models;
using NexusAPI.CicloVidaAtivo.Services;
using NexusAPI.Compartilhado.EntidadesBase;
using NexusAPI.Compartilhado.RespostasAPI;

namespace NexusAPI.CicloVidaAtivo.Controllers
{
    [Controller]
    [Authorize]
    [Route("api/[controller]")]
    public class CicloVidaController : ControllerBase
    {

        [HttpPost("iniciar")]
        public async Task<IActionResult> PostCicloVidaIniciar([FromBody] CicloVidaEnvioDTO envioDTO)
        {
            try
            {
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500, RespostaErroAPI.RespostaErro500);
            }
        }

        [HttpPost("responder")]
        public async Task<IActionResult> PostCicloVidaResponder([FromBody] CicloVidaEnvioDTO envioDTO)
        {
            try
            {
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500, RespostaErroAPI.RespostaErro500);
            }
        }
    }
}
