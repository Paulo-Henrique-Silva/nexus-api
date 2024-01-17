using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NexusAPI.CicloVidaAtivo.DTOs.CicloVida;
using NexusAPI.CicloVidaAtivo.Services;
using NexusAPI.Compartilhado.RespostasAPI;

namespace NexusAPI.CicloVidaAtivo.Controllers
{
    [Controller]
    [Authorize]
    [Route("api/CicloVida/[controller]")]
    public class AnaliseRequisicaoController : ControllerBase
    {
        private readonly AnaliseRequisicaoService analiseRequisicaoService;

        public AnaliseRequisicaoController(AnaliseRequisicaoService analiseRequisicaoService)
        {
            this.analiseRequisicaoService = analiseRequisicaoService;
        }

        [HttpPost("iniciar")]
        public async Task<IActionResult> PostCicloVidaIniciar([FromBody] CicloVidaIniciarDTO envioDTO)
        {
            try
            {
                await analiseRequisicaoService.IniciarCiclovida();
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500, RespostaErroAPI.RespostaErro500);
            }
        }

        [HttpPost("AnaliseCoordenador")]
        public async Task<IActionResult> PostResponderAnaliseCoordenador(
            [FromBody] CicloVidaResponderDTO responderDTO)
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

        [HttpPost("CoordenadorCompletou")]
        public async Task<IActionResult> PostResponderCoordenadorCompletou(
            [FromBody] CicloVidaResponderDTO responderDTO)
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
