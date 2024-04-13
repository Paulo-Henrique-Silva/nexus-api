using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NexusAPI.Compartilhado.EntidadesBase.DTOs;
using NexusAPI.Compartilhado.EntidadesBase.MVC;
using NexusAPI.Compartilhado.EntidadesBase.Objetos;
using NexusAPI.Compartilhado.RespostasAPI;
using NexusAPI.Dados.DTOs.Equipamento;
using NexusAPI.Dados.Enums;
using NexusAPI.Dados.Models;
using NexusAPI.Dados.Services;

namespace NexusAPI.Dados.Controllers
{
    [Controller]
    [Authorize]
    public class EquipamentoController : NexusController<EquipamentoEnvioDTO, EquipamentoRespostaDTO, Equipamento>
    {
        public EquipamentoController(EquipamentoService service) : base(service)
        {
        }

        [HttpGet("Projeto/{projetoUID}")]
        public async Task<IActionResult> GetPorProjeto([FromRoute] string projetoUID, [FromQuery] string? nome = null, [FromQuery] int pagina = 1)
        {
            try
            {
                var objetos = nome == null ? await service.ObterTudoPorProjetoUIDAsync(pagina, projetoUID) :
                    await service.ObterTudoPorProjetoENomeAsync(pagina, projetoUID, nome);

                return Ok(objetos);
            }
            catch (Exception)
            {
                return StatusCode(500, RespostaErroAPI.RespostaErro500);
            }
        }

        [HttpGet("Tipos")]
        public IActionResult GetTipos()
        {
            try
            {
                var valores = Enum.GetValues<TipoEquipamento>();
                var valoresEnum = new NexusEnumDTO[valores.Length];

                for (int i = 0; i < valores.Length; i++)
                {
                    valoresEnum[i] = new NexusEnumDTO()
                    {
                        Nome = NexusManipulacaoEnum.ObterDescricao(valores[i]),
                        UID = i
                    };
                }

                return Ok(valoresEnum);
            }
            catch (Exception)
            {
                return StatusCode(500, RespostaErroAPI.RespostaErro500);
            }
        }
    }
}
