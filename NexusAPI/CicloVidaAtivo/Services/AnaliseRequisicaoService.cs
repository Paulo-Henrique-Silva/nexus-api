using NexusAPI.CicloVidaAtivo.DTOs.CicloVida;
using NexusAPI.CicloVidaAtivo.Repositories;
using NexusAPI.Compartilhado.EntidadesBase.CicloVida;
using NexusAPI.Compartilhado.Services;
using NexusAPI.Dados.Models;
using System.Runtime.Intrinsics.X86;
using System.Security.Claims;

namespace NexusAPI.CicloVidaAtivo.Services
{
    /// <summary>
    /// Uma requisição de novo equipamento é feita por um usuário de Suporte, que indica o coordernador responsável. 
    /// O coordernador aprova ou rejeita. 
    /// Uma notificação é gerada em caso de aprovação ou rejeição. 
    /// Se aprovada, o coordenador deverá completar após o equipamento for adquirido.
    /// </summary>
    public class AnaliseRequisicaoService : NexusCicloVidaService
    {
        public AnaliseRequisicaoService(AtribuicaoService atribuicaoService, TokenService tokenService) 
        : base(atribuicaoService, tokenService)
        {
        }

        public override async Task IniciarCiclovida(CicloVidaIniciarDTO envio, IEnumerable<Claim> claims)
        {
            await AnaliseCoordenador();
        }

        public async Task AnaliseCoordenador()
        {

        }

        public async Task CoordenadorAprovou()
        {

        }

        public async Task CoordenadorReprovou()
        {

        }

        public async Task CoordenadorCompletou()
        {

        }
    }
}
