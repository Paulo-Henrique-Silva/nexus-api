﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NexusAPI.Compartilhado.EntidadesBase.MVC;
using NexusAPI.Compartilhado.RespostasAPI;
using NexusAPI.Dados.DTOs.Componente;
using NexusAPI.Dados.Models;
using NexusAPI.Dados.Services;

namespace NexusAPI.Dados.Controllers
{
    [Controller]
    [Authorize]
    public class ComponenteController
    : NexusController<ComponenteEnvioDTO, ComponenteRespostaDTO, Componente>
    {
        public ComponenteController(ComponenteService service) : base(service)
        {
        }

        [HttpGet("Projeto/{projetoUID}")]
        public async Task<IActionResult> GetPorProjeto([FromRoute] string projetoUID,
            [FromQuery] string? nome = null, [FromQuery] int pagina = 1)
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
    }
}
