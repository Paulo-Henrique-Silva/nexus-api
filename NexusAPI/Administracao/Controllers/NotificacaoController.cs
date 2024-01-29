using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NexusAPI.Administracao.DTOs.Notificacao;
using NexusAPI.Administracao.Models;
using NexusAPI.Administracao.Services;
using NexusAPI.Compartilhado.EntidadesBase.MVC;

namespace NexusAPI.Administracao.Controllers
{
    [Controller]
    [Authorize]
    public class NotificacaoController 
    : NexusController<NotificacaoEnvioDTO, NotificacaoRespostaDTO, Notificacao>
    {
        public NotificacaoController(NotificacaoService service) : base(service)
        {

        }
    }
}
