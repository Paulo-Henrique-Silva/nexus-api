using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NexusAPI.Compartilhado.EntidadesBase;
using NexusAPI.Compartilhado.RespostasAPI;
using NexusAPI.Dados.DTOs.Localizacao;
using NexusAPI.Dados.Models;
using NexusAPI.Dados.Services;

namespace NexusAPI.Dados.Controllers
{
    [Controller]
    [Authorize]
    public class LocalizacaoController
    : NexusController<LocalizacaoEnvioDTO, LocalizacaoRespostaDTO, Localizacao>
    {
        public LocalizacaoController(LocalizacaoService service) : base(service)
        {
        }

        [HttpGet("Projeto/{projetoUID}")]
        public async Task<IActionResult> Get([FromRoute] string projetoUID,
            [FromQuery] int pagina = 1)
        {
            try
            {
                var novoService = service as LocalizacaoService;

                if (novoService == null)
                {
                    throw new Exception("Instância incorreta em service");
                }

                var objetos = await novoService.ObterTudoPorProjetoUIDAsync(pagina, projetoUID);
                return Ok(objetos);
            }
            catch (Exception)
            {
                return StatusCode(500, RespostaErroAPI.RespostaErro500);
            }
        }
    }
}
