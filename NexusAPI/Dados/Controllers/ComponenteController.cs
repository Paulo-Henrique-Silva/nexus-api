using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NexusAPI.Compartilhado.EntidadesBase;
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
    }
}
