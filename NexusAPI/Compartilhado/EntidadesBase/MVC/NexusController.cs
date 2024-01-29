using Microsoft.AspNetCore.Mvc;
using NexusAPI.Administracao.Exceptions;
using NexusAPI.Compartilhado.Exceptions;
using NexusAPI.Compartilhado.RespostasAPI;

namespace NexusAPI.Compartilhado.EntidadesBase.MVC
{
    /// <summary>
    /// Classe utilizada para criar controles da aplicação, com métodos básicos de CRUD.
    /// </summary>
    /// <typeparam name="T">DTO de Envio</typeparam>
    /// <typeparam name="U">DTO de resposta</typeparam>
    /// <typeparam name="O">Classe Base</typeparam>
    [Route("api/[controller]")]
    public class NexusController<T, U, O> : ControllerBase where O : NexusObjeto
    {
        protected readonly NexusService<T, U, O> service;

        public NexusController(NexusService<T, U, O> service)
        {
            this.service = service;
        }

        [HttpGet]
        public virtual async Task<IActionResult> Get([FromQuery] int pagina = 1)
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

        [HttpGet("{UID}")]
        public virtual async Task<IActionResult> Get([FromRoute] string UID)
        {
            try
            {
                var objeto = await service.ObterPorUIDAsync(UID);
                return Ok(objeto);
            }
            catch (ObjetoNaoEncontrado ex)
            {
                return NotFound(new RespostaErroAPI(404, ex.Message));
            }
            catch (Exception)
            {
                return StatusCode(500, RespostaErroAPI.RespostaErro500);
            }
        }

        [HttpPost]
        public virtual async Task<IActionResult> Post([FromBody] T envioDTO)
        {
            try
            {
                var resposta = await service.AdicionarAsync(envioDTO, User.Claims);
                return Created("", resposta);
            }
            catch (NomeAcessoJaCadastrado ex)
            {
                return BadRequest(new RespostaErroAPI(400, ex.Message));
            }
            catch (Exception)
            {
                return StatusCode(500, RespostaErroAPI.RespostaErro500);
            }
        }

        [HttpPut("{UID}")]
        public virtual async Task<IActionResult> Put([FromRoute] string UID,
            [FromBody] T envioDTO)
        {
            try
            {
                var resposta = await service.EditarAsync(UID, envioDTO, User.Claims);
                return Ok(resposta);
            }
            catch (ObjetoNaoEncontrado ex)
            {
                return NotFound(new RespostaErroAPI(404, ex.Message));
            }
            catch (Exception)
            {
                return StatusCode(500, RespostaErroAPI.RespostaErro500);
            }
        }

        [HttpDelete("{UID}")]
        public virtual async Task<IActionResult> Delete([FromRoute] string UID)
        {
            try
            {
                await service.DeletarAsync(UID, User.Claims);
                return Ok();
            }
            catch (ObjetoNaoEncontrado ex)
            {
                return NotFound(new RespostaErroAPI(404, ex.Message));
            }
            catch (Exception)
            {
                return StatusCode(500, RespostaErroAPI.RespostaErro500);
            }
        }
    }
}
