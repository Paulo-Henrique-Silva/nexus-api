using Microsoft.AspNetCore.Mvc;
using NexusAPI.Administracao.DTOs;
using NexusAPI.Administracao.Exceptions;
using NexusAPI.Administracao.Models;
using NexusAPI.Administracao.Services;
using NexusAPI.Compartilhado.RespostasAPI;
using System.Net;

namespace NexusAPI.Administracao.Controllers
{
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
        public async Task<IActionResult> Get()
        {
            return Ok(new Usuario()
            {
                Nome = "Paulo Silva"
            });
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
    }
}
