﻿using AutoMapper;
using NexusAPI.Compartilhado.EntidadesBase.MVC;
using NexusAPI.Compartilhado.EntidadesBase.Objetos;
using NexusAPI.Compartilhado.Services;
using NexusAPI.Dados.DTOs.Manutencao;
using NexusAPI.Dados.DTOs.Requisicao;
using NexusAPI.Dados.Models;
using NexusAPI.Dados.Repositories;

namespace NexusAPI.Dados.Services
{
    public class RequisicaoService
    : NexusService<RequisicaoEnvioDTO, RequisicaoRespostaDTO, Requisicao>
    {
        public RequisicaoService(RequisicaoRepository repository, TokenService tokenService) 
        : base(repository, tokenService)
        {
        }

        public override RequisicaoRespostaDTO ConverterParaDTOResposta(Requisicao obj)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Requisicao, RequisicaoRespostaDTO>()
                    .ForMember(c => c.AtualizadoPor, opt => opt.Ignore())
                    .ForMember(c => c.UsuarioCriador, opt => opt.Ignore())
                    .ForMember(c => c.Coordenador, opt => opt.Ignore())
                    .ForMember(c => c.Projeto, opt => opt.Ignore());
            });
            var mapper = new Mapper(config);

            var resposta = mapper.Map<RequisicaoRespostaDTO>(obj);

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

            resposta.Coordenador = new NexusReferenciaObjeto()
            {
                UID = obj.Coordenador?.UID,
                Nome = obj.Coordenador?.Nome,
            };

            resposta.Projeto = new NexusReferenciaObjeto()
            {
                UID = obj.Projeto?.UID,
                Nome = obj.Projeto?.Nome,
            };

            return resposta;
        }
    }
}
