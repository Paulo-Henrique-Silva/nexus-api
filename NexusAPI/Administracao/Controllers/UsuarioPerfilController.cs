using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NexusAPI.Administracao.DTOs.UsuarioPerfil;
using NexusAPI.Administracao.Exceptions;
using NexusAPI.Administracao.Models;
using NexusAPI.Administracao.Services;
using NexusAPI.Compartilhado.EntidadesBase;
using NexusAPI.Compartilhado.Exceptions;
using NexusAPI.Compartilhado.RespostasAPI;

namespace NexusAPI.Administracao.Controllers
{
    [Controller]
    [Authorize]
    [Route("api/[controller]")]
    public class UsuarioPerfilController : Controller
    {
        private readonly UsuarioPerfilService service;

        public UsuarioPerfilController(UsuarioPerfilService service)
        {
            this.service = service;
        }

        //UID[0] - Usuario
        //UID[1] - Projeto
        //UID[2] - Perfil

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

        [HttpGet("{UIDs}")]
        public virtual async Task<IActionResult> Get([FromRoute] string[] UIDs)
        {
            try
            {
                var UIDsSeparados = UIDs[0].Split(",");

                var objeto = await service.ObterPorUIDAsync(UIDsSeparados[0], UIDsSeparados[1], 
                    UIDsSeparados[2]);
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
        public virtual async Task<IActionResult> Post([FromBody] UsuarioPerfilEnvioDTO envioDTO)
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

        [HttpPut("{UIDs}")]
        public virtual async Task<IActionResult> Put([FromRoute] string[] UIDs, 
            [FromBody] UsuarioPerfilEnvioDTO envioDTO)
        {
            try
            {
                var UIDsSeparados = UIDs[0].Split(",");

                var resposta = await service.EditarAsync(UIDsSeparados[0], UIDsSeparados[1], 
                    UIDsSeparados[2], envioDTO, User.Claims);
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

        [HttpDelete("{UIDs}")]
        public virtual async Task<IActionResult> Delete([FromRoute] string[] UIDs)
        {
            try
            {
                var UIDsSeparados = UIDs[0].Split(",");

                await service.DeletarAsync(UIDsSeparados[0], UIDsSeparados[1], UIDsSeparados[2], 
                    User.Claims);
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
