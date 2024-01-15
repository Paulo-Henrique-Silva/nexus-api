using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NexusAPI.Compartilhado.EntidadesBase;
using NexusAPI.Dados.DTOs.Equipamento;
using NexusAPI.Dados.Models;
using NexusAPI.Dados.Services;

namespace NexusAPI.Dados.Controllers
{
    [Controller]
    [Authorize]
    public class EquipamentoController
    : NexusController<EquipamentoEnvioDTO, EquipamentoRespostaDTO, Equipamento>
    {
        public EquipamentoController(EquipamentoService service) : base(service)
        {
        }
    }
}
