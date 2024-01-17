using Microsoft.AspNetCore.Razor.Hosting;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using NexusAPI.CicloVidaAtivo.Enums;
using NexusAPI.CicloVidaAtivo.Models;
using NexusAPI.Dados.Models;
using System.Runtime.Intrinsics.X86;

namespace NexusAPI.CicloVidaAtivo.Services
{
    /// <summary>
    /// Classe para armazenar e instanciar ciclos de vida.
    /// </summary>
    public static class TiposCicloVidaService
    {

        /// <summary>
        /// Ciclo de vida de requisição.
        /// Uma requisição de novo equipamento é feita por um usuário de Suporte, que indica o coordernador responsável.
	    /// O coordernador aprova ou rejeita.
        /// Uma notificação é gerada em caso de aprovação ou rejeição.
        /// Se aprovada, o coordenador deverá completar após o equipamento for adquirido.
        /// </summary>
        public static CicloVida NexusRequisicao 
        { 
            get 
            {
                string CicloUID = Guid.NewGuid().ToString();

                return new()
                {
                    UID = CicloUID,

                    Nome = "Análise de Requisicao",

                    Descricao = "Análise das requisições pelo coordenador.",

                    Passos =
                    [
                        new()
                        {
                            UID = "AnaliseCoordenador" + CicloUID,
                            CicloVidaUID = CicloUID,
                            Nome = "Análise do Coordenador",
                            Descricao = "Coordenador recebe a requisição para aprová-la ou rejeitá-la.",
                            Metodo = "RequisicoesAnaliseCoordenador",
                            PassoSucessoUID = "CoordenadorAprovou" + CicloUID,
                            PassoFalhaUID = "CoordenadorReprovou" + CicloUID
                        },
                        new()
                        {
                            UID = "CoordenadorReprovou" + CicloUID,
                            CicloVidaUID = CicloUID,
                            Nome = "Coordenador reprovou",
                            Descricao = "Coordenador reprovou a requisição.",
                            Metodo = "RequisicoesReprovar"
                        },
                        new()
                        {
                            UID = "CoordenadorAprovou" + CicloUID,
                            CicloVidaUID = CicloUID,
                            Nome = "Coordenador aprovou",
                            Descricao = "Coordenador aprovou a requisição.",
                            Metodo = "RequisicoesAprovar",
                            PassoSucessoUID = "CoordenadorCompletou" + CicloUID,
                        },
                        new()
                        {
                            UID = "CoordenadorCompletou" + CicloUID,
                            CicloVidaUID = CicloUID,
                            Nome = "Coordenador completou",
                            Descricao = "Coordenador completou a requisição.",
                            Metodo = "RequisicoesCompletar"
                        }
                    ]};
            } 
        } 
    }
}
