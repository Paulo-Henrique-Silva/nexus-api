using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NexusAPI.Compartilhado.EntidadesBase.MVC;
using NexusAPI.Compartilhado.RespostasAPI;
using NexusAPI.Dados.DTOs.Equipamento;
using NexusAPI.Dados.Models;
using NexusAPI.Dados.Services;

namespace NexusAPI.Dados.Controllers
{
    [Controller]
    [Authorize]
    public class EquipamentoController
    : NexusController<EquipamentoEnvioDTO, EquipamentoRespostaDTO, Equipamento>
    {
        public EquipamentoController(EquipamentoService service) : base(service)
        {
        }

        [HttpGet("Projeto/{projetoUID}")]
        public async Task<IActionResult> Get([FromRoute] string projetoUID,
            [FromQuery] int pagina = 1)
        {
            try
            {
                var novoService = service as EquipamentoService;

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
