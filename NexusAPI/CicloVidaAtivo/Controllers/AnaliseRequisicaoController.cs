using Microsoft.AspNetCore.Mvc;
using NexusAPI.CicloVidaAtivo.DTOs.CicloVida;
using NexusAPI.CicloVidaAtivo.Services;
using NexusAPI.Compartilhado.EntidadesBase.CicloVida;
using NexusAPI.Compartilhado.RespostasAPI;

namespace NexusAPI.CicloVidaAtivo.Controllers
{
    [Controller]
    public class AnaliseRequisicaoController : NexusCicloVidaController
    {
        public AnaliseRequisicaoController(AnaliseRequisicaoService nexusCicloVidaService) 
        : base(nexusCicloVidaService)
        {
            
        }

        [HttpPost("AnaliseCoordenador")]
        public async Task<IActionResult> PostResponderAnaliseCoordenador(
            [FromBody] CicloVidaResponderDTO responderDTO)
        {
            try
            {
                var serviceAnaliseRequisicao = service as AnaliseRequisicaoService;

                if (responderDTO.Sucesso)
                {
                    await serviceAnaliseRequisicao.CoordenadorAprovou(responderDTO, User.Claims);
                }
                else
                {
                    await serviceAnaliseRequisicao.CoordenadorReprovou(responderDTO, User.Claims);
                }

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
                var serviceAnaliseRequisicao = service as AnaliseRequisicaoService;
                await serviceAnaliseRequisicao.CoordenadorCompletou(responderDTO, User.Claims);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500, RespostaErroAPI.RespostaErro500);
            }
        }
    }
}
