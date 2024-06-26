﻿using AutoMapper;
using NexusAPI.Compartilhado.EntidadesBase.MVC;
using NexusAPI.Compartilhado.EntidadesBase.Objetos;
using NexusAPI.Compartilhado.Services;
using NexusAPI.Dados.DTOs.Componente;
using NexusAPI.Dados.Exceptions;
using NexusAPI.Dados.Models;
using NexusAPI.Dados.Repositories;
using System.Security.Claims;

namespace NexusAPI.Dados.Services
{
    public class ComponenteService : NexusService<ComponenteEnvioDTO, ComponenteRespostaDTO, Componente>
    {
        private readonly ComponenteRepository componenteRepository;

        public ComponenteService(ComponenteRepository repository, TokenService tokenService) 
        : base(repository, tokenService)
        {
            componenteRepository = repository;
        }

        public override ComponenteRespostaDTO ConverterParaDTOResposta(Componente obj)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Componente, ComponenteRespostaDTO>()
                    .ForMember(c => c.AtualizadoPor, opt => opt.Ignore())
                    .ForMember(c => c.UsuarioCriador, opt => opt.Ignore())
                    .ForMember(c => c.Localizacao, opt => opt.Ignore())
                    .ForMember(c => c.Projeto, opt => opt.Ignore())
                    .ForMember(c => c.Tipo, opt => opt.Ignore())
                    .ForMember(c => c.Status, opt => opt.Ignore());
            });
            var mapper = new Mapper(config);

            var resposta = mapper.Map<ComponenteRespostaDTO>(obj);

            resposta.AtualizadoPor = new NexusReferenciaObjeto()
            {
                UID = obj.AtualizadoPor?.UID,
                Nome = obj.AtualizadoPor?.Nome
            };

            resposta.UsuarioCriador = new NexusReferenciaObjeto()
            {
                UID = obj.UsuarioCriador?.UID,
                Nome = obj.UsuarioCriador?.Nome
            };

            resposta.Localizacao = new NexusReferenciaObjeto()
            {
                UID = obj.Localizacao?.UID,
                Nome = obj.Localizacao?.Nome,
            };

            resposta.Projeto = new NexusReferenciaObjeto()
            {
                UID = obj.Projeto?.UID,
                Nome = obj.Projeto?.Nome,
            };

            resposta.Tipo = new NexusReferenciaObjeto()
            {
                UID = ((int)obj.Tipo).ToString(),
                Nome = NexusManipulacaoEnum.ObterDescricao(obj.Tipo),
            };

            resposta.Status = new NexusReferenciaObjeto()
            {
                UID = ((int)obj.Status).ToString(),
                Nome = NexusManipulacaoEnum.ObterDescricao(obj.Status),
            };

            return resposta;
        }

        public override async Task<ComponenteRespostaDTO> AdicionarAsync(ComponenteEnvioDTO obj, IEnumerable<Claim> claims)
        {
            var objClasse = ConverterParaClasse(obj);

            if (await componenteRepository.ObterPorNumeroSerieAsync(objClasse.NumeroSerie) != null)
            {
                throw new NumeroSerieJaCadastrado();
            }

            objClasse.UID = Guid.NewGuid().ToString();
            objClasse.UsuarioCriadorUID = tokenService.ObterUsuarioUID(claims);

            var UID = (await repository.AdicionarAsync(objClasse)).UID;

            var objAposSerCriado = await repository.ObterPorUIDAsync(UID);

            if (objAposSerCriado == null)
            {
                throw new Exception("Objeto atualizado não foi encontrado.");
            }

            return ConverterParaDTOResposta(objAposSerCriado);
        }
    }
}
