using Microsoft.AspNetCore.Mvc;
using NexusAPI.CicloVidaAtivo.DTOs.CicloVida;
using NexusAPI.CicloVidaAtivo.Services;
using NexusAPI.Compartilhado.EntidadesBase.CicloVida;
using NexusAPI.Compartilhado.RespostasAPI;

namespace NexusAPI.CicloVidaAtivo.Controllers
{
    /// <summary>
    /// Usuários podem criar manutenções. As manutenções podem ser atribuídas para 
    /// o próprio usuário ou para outro. O usuário atribuído deverá marcar a manuteção como concluída, depois que preencher
    /// o campo de solução.
    /// </summary>
    [Controller]
    public class VerificacaoManutencaoController : NexusCicloVidaController
    {
        public VerificacaoManutencaoController(VerificacaoManutencaoService service) 
        : base(service) { }

        [HttpPost("UsuarioConcluiu")]
        public async Task<IActionResult> PostResponderUsuarioConcluiu(
            [FromBody] CicloVidaResponderDTO responderDTO)
        {
            try
            {
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500, RespostaErroAPI.RespostaErro500);
            }
        }
    }
}
