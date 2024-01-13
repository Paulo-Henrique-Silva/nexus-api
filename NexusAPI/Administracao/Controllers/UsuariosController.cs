﻿using Microsoft.AspNetCore.Mvc;
using NexusAPI.Administracao.Models;

namespace NexusAPI.Administracao.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new Usuario("Paulo Silva", "paulo.silva", "123", Guid.NewGuid().ToString()));
        }
    }
}
