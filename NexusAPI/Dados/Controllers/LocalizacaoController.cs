using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NexusAPI.Compartilhado.EntidadesBase;
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
    }
}
