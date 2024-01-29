using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NexusAPI.Administracao.DTOs.Projeto;
using NexusAPI.Administracao.Models;
using NexusAPI.Administracao.Services;
using NexusAPI.Compartilhado.EntidadesBase.MVC;

namespace NexusAPI.Administracao.Controllers
{
    [Controller]
    [Authorize]
    public class ProjetoController : NexusController<ProjetoEnvioDTO, ProjetoRespostaDTO, Projeto>
    {
        public ProjetoController(ProjetoService service) : base(service)
        {
        }
    }
}
