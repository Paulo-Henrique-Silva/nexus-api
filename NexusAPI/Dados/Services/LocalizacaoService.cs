using NexusAPI.Administracao.DTOs.Projeto;
using NexusAPI.Administracao.Models;
using NexusAPI.Compartilhado.EntidadesBase;
using NexusAPI.Compartilhado.Services;
using NexusAPI.Dados.DTOs.Localizacao;
using NexusAPI.Dados.Models;

namespace NexusAPI.Dados.Services
{
    public class LocalizacaoService
    : NexusService<LocalizacaoEnvioDTO, LocalizacaoRespostaDTO, Localizacao>
    {
        public LocalizacaoService(NexusRepository<Localizacao> repository, TokenService tokenService) 
        : base(repository, tokenService)
        {
        }

        public override Localizacao ConverterParaClasse(LocalizacaoEnvioDTO obj)
        {
            var resposta = new Localizacao()
            {
                Nome = obj.Nome,
                Descricao = obj.Descricao
            };

            return resposta;
        }

        public override LocalizacaoRespostaDTO ConverterParaDTORespostaAsync(Localizacao obj)
        {
            var resposta = new LocalizacaoRespostaDTO()
            {
                UID = obj.UID,
                Nome = obj.Nome,
                Descricao = obj.Descricao,

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
            };

            return resposta;
        }
    }
}
