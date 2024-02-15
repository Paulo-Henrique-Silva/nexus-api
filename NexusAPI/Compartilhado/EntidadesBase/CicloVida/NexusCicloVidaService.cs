using NexusAPI.Administracao.Services;
using NexusAPI.CicloVidaAtivo.DTOs.CicloVida;
using NexusAPI.CicloVidaAtivo.Repositories;
using NexusAPI.CicloVidaAtivo.Services;
using NexusAPI.Compartilhado.Services;
using System.Security.Claims;

namespace NexusAPI.Compartilhado.EntidadesBase.CicloVida
{
    public abstract class NexusCicloVidaService
    {
        protected readonly AtribuicaoService atribuicaoService;

        protected readonly NotificacaoService notificacaoService;

        protected readonly TokenService tokenService;

        protected NexusCicloVidaService(
            AtribuicaoService atribuicaoService, 
            NotificacaoService notificacaoService,
            TokenService tokenService)
        {
            this.atribuicaoService = atribuicaoService;
            this.notificacaoService = notificacaoService;
            this.tokenService = tokenService;
        }

        public abstract Task IniciarCiclovida(CicloVidaIniciarDTO envioDTO, IEnumerable<Claim> claims);

        protected static DateTime ObterDataDiasUteis(int quantidadeDiasUteis)
        {
            int diasUteis = 0;
            DateTime data = DateTime.Now;

            while (diasUteis < quantidadeDiasUteis)
            {
                data = data.AddDays(1);

                if (data.DayOfWeek != DayOfWeek.Saturday && data.DayOfWeek != DayOfWeek.Sunday)
                {
                    diasUteis++;
                }
            }

            //Muda o horário para 17:59, fim do horário comercial.
            return new DateTime(data.Year, data.Month, data.Day, 17, 59, 59);
        }
    }
}
