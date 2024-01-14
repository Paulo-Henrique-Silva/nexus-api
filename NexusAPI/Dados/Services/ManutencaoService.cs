using NexusAPI.Administracao.Models;
using NexusAPI.Compartilhado.EntidadesBase;
using NexusAPI.Compartilhado.Services;
using NexusAPI.Dados.DTOs.Componente;
using NexusAPI.Dados.DTOs.Manutencao;
using NexusAPI.Dados.Models;

namespace NexusAPI.Dados.Services
{
    public class ManutencaoService : NexusService<ManutencaoEnvioDTO, ManutencaoRespostaDTO, Manutencao>
    {
        public ManutencaoService(NexusRepository<Manutencao> repository, TokenService tokenService) 
        : base(repository, tokenService)
        {
        }

        public override Manutencao ConverterParaClasse(ManutencaoEnvioDTO obj)
        {
            var resposta = new Manutencao()
            {
                Nome = obj.Nome,
                Descricao = obj.Descricao,
                ComponenteUID = obj.ComponenteUID,
                DataInicio = obj.DataInicio, 
                DataTermino = obj.DataTermino,
                ResponsavelUID = obj.ResponsavelUID,
                Solucao = obj.Solucao,
            };

            return resposta;
        }

        public override ManutencaoRespostaDTO ConverterParaDTORespostaAsync(Manutencao obj)
        {
            var resposta = new ManutencaoRespostaDTO()
            {
                UID = obj.UID,
                Nome = obj.Nome,
                Descricao = obj.Descricao,
                DataInicio = obj.DataInicio,
                DataTermino = obj.DataTermino,
                ResponsavelUID = obj.ResponsavelUID,
                Solucao = obj.Solucao,

                DataUltimaAtualizacao = obj.DataUltimaAtualizacao,
                AtualizadoPor = new NexusNomeObjeto()
                {
                    UID = obj.AtualizadoPor?.UID,
                    Nome = obj.AtualizadoPor?.Nome
                },

                DataCriacao = obj.DataCriacao,
                UsuarioCriador = new NexusNomeObjeto()
                {
                    UID = obj.UsuarioCriador?.UID,
                    Nome = obj.UsuarioCriador?.Nome
                },

                Componente = new NexusNomeObjeto()
                {
                    UID = obj.Componente?.UID,
                    Nome = obj.Componente?.Nome
                },
            };

            return resposta;
        }
    }
}
