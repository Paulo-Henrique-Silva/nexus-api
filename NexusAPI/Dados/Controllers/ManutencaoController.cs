using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NexusAPI.Compartilhado.EntidadesBase;
using NexusAPI.Dados.DTOs.Manutencao;
using NexusAPI.Dados.Models;
using NexusAPI.Dados.Services;

namespace NexusAPI.Dados.Controllers
{
    [Controller]
    [Authorize]
    public class ManutencaoController
    : NexusController<ManutencaoEnvioDTO, ManutencaoRespostaDTO, Manutencao>
    {
        public ManutencaoController(ManutencaoService service) : base(service)
        {
        }
    }
}
