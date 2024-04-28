using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NexusAPI.Administracao.DTOs.Usuario;
using NexusAPI.Administracao.Exceptions;
using NexusAPI.Administracao.Models;
using NexusAPI.Administracao.Services;
using NexusAPI.CicloVidaAtivo.Services;
using NexusAPI.Compartilhado.EntidadesBase.MVC;
using NexusAPI.Compartilhado.Exceptions;
using NexusAPI.Compartilhado.RespostasAPI;

namespace NexusAPI.Administracao.Controllers
{
    [Controller]
    public class UsuarioController : NexusController<UsuarioEnvioDTO, UsuarioRespostaDTO, Usuario>
    {
        private readonly NotificacaoService notificacaoService;

        private readonly AtribuicaoService atribuicaoService;

        private readonly UsuarioService usuarioService;

        public UsuarioController(UsuarioService service, NotificacaoService notificacaoService,
            AtribuicaoService atribuicaoService) 
        : base(service) 
        { 
            this.notificacaoService = notificacaoService;
            this.atribuicaoService = atribuicaoService;

            usuarioService = service;
        }

        [HttpGet]
        [Authorize]
        public override async Task<IActionResult> Get([FromQuery] string? nome = null, int? numeroPagina = 0)
        {
            try
            {
                //Se não tiver nome, procura todos os usuários, senão filtra os usuários por nome.
                var usuarios = nome == null ? await usuarioService.ObterTudoAsync() : await usuarioService.ObterTudoPorNomeAsync(nome);

                return Ok(usuarios);
            }
            catch (Exception)
            {
                return StatusCode(500, RespostaErroAPI.RespostaErro500);
            }
        }

        [HttpGet("Coordenadores")]
        [Authorize]
        public async Task<IActionResult> GetCoordenadores([FromQuery] string nome, [FromQuery] string projetoUID)
        {
            try
            {
                //Filtra os coordenador por nome
                var usuarios = await usuarioService.ObterCoordenadoresPorNomeAsync(nome, projetoUID);
                return Ok(usuarios);
            }
            catch (Exception)
            {
                return StatusCode(500, RespostaErroAPI.RespostaErro500);
            }
        }

        [HttpGet("{UID}")]
        [Authorize]
        public override async Task<IActionResult> GetByUID([FromRoute] string UID)
        {
            try
            {
                var usuario = await usuarioService.ObterPorUIDAsync(UID);
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
        public override async Task<IActionResult> Post([FromBody] UsuarioEnvioDTO usuarioEnvioDTO)
        {
            try
            {
                var usuario = await usuarioService.AdicionarAsync(usuarioEnvioDTO, User.Claims);
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
        public override async Task<IActionResult> Put([FromRoute] string UID, [FromBody] UsuarioEnvioDTO usuarioEnvioDTO)
        {
            try
            {
                var usuario = await usuarioService.EditarAsync(UID, usuarioEnvioDTO, User.Claims);
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
                await usuarioService.DeletarAsync(UID, User.Claims);
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

        [HttpGet("{UID}/Notificacoes")]
        [Authorize]
        public async Task<IActionResult> GetNotificacoes([FromRoute] string UID)
        {
            try
            {
                var usuario = await notificacaoService.ObterTudoPorUsuarioUIDAsync(UID);
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

        [HttpGet("{UID}/Atribuicoes")]
        [Authorize]
        public async Task<IActionResult> GetAtribuicoes([FromRoute] string UID)
        {
            try
            {
                var usuario = await atribuicaoService.ObterTudoPorUsuarioUIDAsync(UID);
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

        [HttpPost("{UID}/Senha")]
        [Authorize]
        public async Task<IActionResult> GetNotificacoes([FromRoute] string UID, 
            [FromBody] UsuarioEnvioDTO usuarioEnvioDTO)
        {
            try
            {
                var senhaCorretaDTO = await usuarioService.VerificarSenha(UID, usuarioEnvioDTO);
                return Ok(senhaCorretaDTO);
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
