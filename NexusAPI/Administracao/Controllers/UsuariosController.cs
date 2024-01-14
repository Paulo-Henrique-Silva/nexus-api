using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NexusAPI.Administracao.DTOs;
using NexusAPI.Administracao.Exceptions;
using NexusAPI.Administracao.Models;
using NexusAPI.Administracao.Services;
using NexusAPI.Compartilhado.Exceptions;
using NexusAPI.Compartilhado.RespostasAPI;
using System.Net;

namespace NexusAPI.Administracao.Controllers
{
    //TODO: Criar classe BaseController para reutilizar endpoints comuns.

    [Controller]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly UsuariosService usuariosService;

        public UsuariosController(UsuariosService usuariosService)
        {
            this.usuariosService = usuariosService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Get([FromQuery] int pagina = 1)
        {
            try
            {
                var usuarios = await usuariosService.ObterTudoAsync(pagina);
                return Ok(usuarios);
            }
            catch (Exception)
            {
                return StatusCode(500, RespostaErroAPI.RespostaErro500);
            }
        }

        [HttpGet("{UID}")]
        [Authorize]
        public async Task<IActionResult> Get([FromRoute] string UID)
        {
            try
            {
                var usuario = await usuariosService.ObterPorUIDAsync(UID);
                return Ok(usuario);
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
        public async Task<IActionResult> Post([FromBody] UsuarioEnvioDTO usuarioEnvioDTO)
        {
            try
            {
                var usuario = await usuariosService.AdicionarAsync(usuarioEnvioDTO);
                return Created("", usuario);
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
        [Authorize]
        public async Task<IActionResult> Put([FromRoute] string UID, 
            [FromBody] UsuarioEnvioDTO usuarioEnvioDTO)
        {
            try
            {
                var usuario = await usuariosService.EditarAsync(UID, usuarioEnvioDTO);
                return Ok(usuario);
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
        [Authorize]
        public async Task<IActionResult> Delete([FromRoute] string UID)
        {
            try
            {
                await usuariosService.DeletarAsync(UID);
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

        [HttpPost("login")]
        public async Task<IActionResult> PostLogin([FromBody] UsuarioEnvioDTO usuarioEnvioDTO)
        {
            try
            {
                var token = await usuariosService.AutenticarUsuario(usuarioEnvioDTO);
                return Ok(token);
            }
            catch (CredenciaisIncorretas ex)
            {
                return Unauthorized(new RespostaErroAPI(401, ex.Message));
            }
            catch (Exception)
            {
                return StatusCode(500, RespostaErroAPI.RespostaErro500);
            }
        }
    }
}
