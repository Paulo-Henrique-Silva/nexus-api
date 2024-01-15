﻿using AutoMapper;
using NexusAPI.Administracao.Models;
using NexusAPI.Compartilhado.EntidadesBase;
using NexusAPI.Compartilhado.Services;
using NexusAPI.Dados.DTOs.Componente;
using NexusAPI.Dados.DTOs.Manutencao;
using NexusAPI.Dados.Models;
using NexusAPI.Dados.Repositories;

namespace NexusAPI.Dados.Services
{
    public class ManutencaoService : NexusService<ManutencaoEnvioDTO, ManutencaoRespostaDTO, Manutencao>
    {
        public ManutencaoService(ManutencaoRepository repository, TokenService tokenService) 
        : base(repository, tokenService)
        {
        }

        public override ManutencaoRespostaDTO ConverterParaDTORespostaAsync(Manutencao obj)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Manutencao, ManutencaoRespostaDTO>()
                    .ForMember(c => c.AtualizadoPor, opt => opt.Ignore())
                    .ForMember(c => c.UsuarioCriador, opt => opt.Ignore())
                    .ForMember(c => c.Componente, opt => opt.Ignore())
                    .ForMember(c => c.Responsavel, opt => opt.Ignore());
            });
            var mapper = new Mapper(config);

            var resposta = mapper.Map<ManutencaoRespostaDTO>(obj);

            resposta.AtualizadoPor = new NexusNomeObjeto()
            {
                UID = obj.AtualizadoPor?.UID,
                Nome = obj.AtualizadoPor?.Nome
            };

            resposta.UsuarioCriador = new NexusNomeObjeto()
            {
                UID = obj.UsuarioCriador?.UID,
                Nome = obj.UsuarioCriador?.Nome
            };

            resposta.Componente = new NexusNomeObjeto()
            {
                UID = obj.Componente?.UID,
                Nome = obj.Componente?.Nome,
            };

            resposta.Responsavel = new NexusNomeObjeto()
            {
                UID = obj.Responsavel?.UID,
                Nome = obj.Responsavel?.Nome,
            };

            return resposta;
        }
    }
}
