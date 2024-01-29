﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NexusAPI.Compartilhado.EntidadesBase.MVC;
using NexusAPI.Compartilhado.RespostasAPI;
using NexusAPI.Dados.DTOs.Requisicao;
using NexusAPI.Dados.Models;
using NexusAPI.Dados.Services;

namespace NexusAPI.Dados.Controllers
{
    [Controller]
    [Authorize]
    public class RequisicaoController
    : NexusController<RequisicaoEnvioDTO, RequisicaoRespostaDTO, Requisicao>
    {
        public RequisicaoController(RequisicaoService service) : base(service)
        {
        }

        [HttpGet("Projeto/{projetoUID}")]
        public async Task<IActionResult> Get([FromRoute] string projetoUID,
            [FromQuery] int pagina = 1)
        {
            try
            {
                var objetos = await service.ObterTudoPorProjetoUIDAsync(pagina, projetoUID);
                return Ok(objetos);
            }
            catch (Exception)
            {
                return StatusCode(500, RespostaErroAPI.RespostaErro500);
            }
        }
    }
}
