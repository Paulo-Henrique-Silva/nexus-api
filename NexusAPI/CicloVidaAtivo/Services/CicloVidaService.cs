using AutoMapper;
using NexusAPI.CicloVidaAtivo.DTOs;
using NexusAPI.CicloVidaAtivo.Models;
using NexusAPI.CicloVidaAtivo.Repositories;
using NexusAPI.Compartilhado.EntidadesBase;
using NexusAPI.Compartilhado.Services;
using NexusAPI.Dados.DTOs.Componente;

namespace NexusAPI.CicloVidaAtivo.Services
{
    public class CicloVidaService
    {
        #region CicloVidas
        public static List<CicloVida> CiclosVida
        {
            get
            {
                string CicloUID = Guid.NewGuid().ToString();

                var lista = new List<CicloVida>
                {
                    new()
                    {
                        UID = CicloUID,

                        Nome = "Análise de Requisicao",

                        Descricao = "Análise das requisições pelo coordenador.",

                        Tipo = Enums.TipoCicloVida.AnaliseRequisicao,

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
                        ]
                    },
                    new()
                    {
                        UID = CicloUID,

                        Nome = "Análise de Manutenção",

                        Descricao = "Análise das manutenções pelo coordenador.",

                        Tipo = Enums.TipoCicloVida.AnaliseManutencao,

                        Passos =
                        [
                            new()
                            {
                                UID = "CriacaoManutencao" + CicloUID,
                                CicloVidaUID = CicloUID,
                                Nome = "Manutenção Criada",
                                Descricao = "Usuário cria manutenção.",
                                Metodo = "RequisicoesAnaliseCoordenador",
                                PassoSucessoUID = "CriarManutencao" + CicloUID
                            },
                            new()
                            {
                                UID = "UsuarioConcluiu" + CicloUID,
                                CicloVidaUID = CicloUID,
                                Nome = "Usuário conclui a manutenção, após preencher a solução.",
                                Descricao = "Coordenador reprovou a requisição.",
                                Metodo = "ConcluirManutencao"
                            }
                        ]
                    }
                };

                return lista;
            }
        }
        #endregion

        private readonly CicloVidaRepository cicloVidaRepository;

        private readonly CicloVidaPassoRepository cicloVidaPassoRepository;

        private readonly AtribuicaoRepository atribuicaoRepository;

        private readonly TokenService tokenService;

        public CicloVidaService(CicloVidaRepository cicloVidaRepository, 
            CicloVidaPassoRepository cicloVidaPassoRepository, AtribuicaoRepository atribuicaoRepository, 
            TokenService tokenService)
        {
            this.cicloVidaRepository = cicloVidaRepository;
            this.cicloVidaPassoRepository = cicloVidaPassoRepository;
            this.atribuicaoRepository = atribuicaoRepository;
            this.tokenService = tokenService;
        }
    }
}
