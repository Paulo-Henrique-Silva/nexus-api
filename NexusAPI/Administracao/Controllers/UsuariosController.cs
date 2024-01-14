using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NexusAPI.Administracao.DTOs.Usuario;
using NexusAPI.Administracao.Exceptions;
using NexusAPI.Administracao.Models;
using NexusAPI.Administracao.Services;
using NexusAPI.Compartilhado.EntidadesBase;
using NexusAPI.Compartilhado.Exceptions;
using NexusAPI.Compartilhado.RespostasAPI;
using System.Net;

namespace NexusAPI.Administracao.Controllers
{
    [Controller]
    public class UsuariosController 
    : NexusController<UsuarioEnvioDTO, UsuarioRespostaDTO, Usuario>
    {
        public UsuariosController(UsuariosService service) : base(service) { }

        [HttpGet]
        [Authorize]
        public override async Task<IActionResult> Get([FromQuery] int pagina = 1)
        {
            try
            {
                var usuarios = await service.ObterTudoAsync(pagina);
                return Ok(usuarios);
            }
            catch (Exception)
            {
                return StatusCode(500, RespostaErroAPI.RespostaErro500);
            }
        }

        [HttpGet("{UID}")]
        [Authorize]
        public override async Task<IActionResult> Get([FromRoute] string UID)
        {
            try
            {
                var usuario = await service.ObterPorUIDAsync(UID);
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
        public override async Task<IActionResult> Post(
            [FromBody] UsuarioEnvioDTO usuarioEnvioDTO)
        {
            try
            {
                var usuario = await service.AdicionarAsync(usuarioEnvioDTO, User.Claims);
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
        public override async Task<IActionResult> Put([FromRoute] string UID, 
            [FromBody] UsuarioEnvioDTO usuarioEnvioDTO)
        {
            try
            {
                var usuario = await service.EditarAsync(UID, usuarioEnvioDTO, User.Claims);
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
        public override async Task<IActionResult> Delete([FromRoute] string UID)
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

        [HttpPost("login")]
        public async Task<IActionResult> PostLogin([FromBody] UsuarioEnvioDTO usuarioEnvioDTO)
        {
            try
            {
                var usuarioService = service as UsuariosService;

                if (usuarioService == null)
                {
                    throw new Exception("Instância incorreta da classe.");
                }

                var token = await usuarioService.AutenticarUsuario(usuarioEnvioDTO);
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
