using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NexusAPI.CicloVidaAtivo.DTOs.Atribuicao;
using NexusAPI.CicloVidaAtivo.Models;
using NexusAPI.CicloVidaAtivo.Services;
using NexusAPI.Compartilhado.EntidadesBase;

namespace NexusAPI.CicloVidaAtivo.Controllers
{
    [Controller]
    [Authorize]
    public class AtribuicaoController
    : NexusController<AtribuicaoEnvioDTO, AtribuicaoRespostaDTO, Atribuicao>
    {
        public AtribuicaoController(AtribuicaoService service) : base(service)
        {
        }
    }
}
