using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NexusAPI.Compartilhado.EntidadesBase;
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
    }
}
