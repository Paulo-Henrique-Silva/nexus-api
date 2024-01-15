﻿using AutoMapper;
using NexusAPI.CicloVidaAtivo.DTOs.CicloVida;
using NexusAPI.CicloVidaAtivo.Models;
using NexusAPI.CicloVidaAtivo.Repositories;
using NexusAPI.Compartilhado.EntidadesBase;
using NexusAPI.Compartilhado.Services;
using NexusAPI.Dados.DTOs.Componente;

namespace NexusAPI.CicloVidaAtivo.Services
{
    public class CicloVidaService : NexusService<CicloVidaEnvioDTO, CicloVidaRespostaDTO, CicloVida>
    {
        public CicloVidaService(CicloVidaRepository repository, TokenService tokenService) : base(repository, tokenService)
        {
        }

        public override CicloVidaRespostaDTO ConverterParaDTORespostaAsync(CicloVida obj)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CicloVida, CicloVidaRespostaDTO>()
                    .ForMember(c => c.AtualizadoPor, opt => opt.Ignore())
                    .ForMember(c => c.UsuarioCriador, opt => opt.Ignore());
            });
            var mapper = new Mapper(config);

            var resposta = mapper.Map<CicloVidaRespostaDTO>(obj);

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

            return resposta;
        }
    }
}
