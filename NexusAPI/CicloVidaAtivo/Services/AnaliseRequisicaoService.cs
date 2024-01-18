using NexusAPI.CicloVidaAtivo.Repositories;
using NexusAPI.Compartilhado.EntidadesBase;
using NexusAPI.Compartilhado.Services;
using NexusAPI.Dados.Models;
using System.Runtime.Intrinsics.X86;

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
        public AnaliseRequisicaoService(AtribuicaoRepository atribuicaoRepository, 
            CicloVidaRepository cicloVidaRepository, TokenService tokenService) 
        : base(atribuicaoRepository, cicloVidaRepository, tokenService)
        {
        }

        public override async Task IniciarCiclovida()
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
