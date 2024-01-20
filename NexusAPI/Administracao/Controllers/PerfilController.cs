using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NexusAPI.Administracao.DTOs.Perfil;
using NexusAPI.Administracao.Models;
using NexusAPI.Administracao.Services;
using NexusAPI.Compartilhado.EntidadesBase;

namespace NexusAPI.Administracao.Controllers
{
    [Controller]
    [Authorize]
    public class PerfilController : NexusController<PerfilEnvioDTO, PerfilRespostaDTO, Perfil>
    {
        public PerfilController(PerfilService service) : base(service)
        {

        }
    }
}
