using NexusAPI.Compartilhado.EntidadesBase;
using NexusAPI.Compartilhado.Services;
using NexusAPI.Dados.DTOs.Componente;
using NexusAPI.Dados.DTOs.Localizacao;
using NexusAPI.Dados.Enums;
using NexusAPI.Dados.Models;

namespace NexusAPI.Dados.Services
{
    public class ComponenteService : NexusService<ComponenteEnvioDTO, ComponenteRespostaDTO, Componente>
    {
        public ComponenteService(NexusRepository<Componente> repository, TokenService tokenService) : base(repository, tokenService)
        {
        }

        public override Componente ConverterParaClasse(ComponenteEnvioDTO obj)
        {
            var resposta = new Componente()
            {
                Nome = obj.Nome,
                Descricao = obj.Descricao,
                NumeroSerie = obj.NumeroSerie,
                LocalizacaoUID = obj.LocalizacaoUID,
                Status = obj.Status,
                Marca = obj.Marca,
                Modelo = obj.Marca,
                Tipo = obj.Tipo,
                DataAquisicao = obj.DataAquisicao
            };

            return resposta;
        }

        public override ComponenteRespostaDTO ConverterParaDTORespostaAsync(Componente obj)
        {
            var resposta = new ComponenteRespostaDTO()
            {
                UID = obj.UID,
                Nome = obj.Nome,
                Descricao = obj.Descricao,
                NumeroSerie = obj.NumeroSerie,
                Status = obj.Status,
                Marca = obj.Marca,
                Modelo = obj.Marca,
                Tipo = obj.Tipo,
                DataAquisicao = obj.DataAquisicao,

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

                Localizacao = new NexusNomeObjeto()
                {
                    UID = obj.Localizacao?.UID,
                    Nome = obj.Localizacao?.Nome
                },
            };

            return resposta;
        }
    }
}
