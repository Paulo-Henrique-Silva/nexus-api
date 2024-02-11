﻿using AutoMapper;
using NexusAPI.Administracao.DTOs.Notificacao;
using NexusAPI.Administracao.Repositories;
using NexusAPI.CicloVidaAtivo.DTOs.Atribuicao;
using NexusAPI.CicloVidaAtivo.Models;
using NexusAPI.CicloVidaAtivo.Repositories;
using NexusAPI.Compartilhado.EntidadesBase.MVC;
using NexusAPI.Compartilhado.EntidadesBase.Objetos;
using NexusAPI.Compartilhado.Services;

namespace NexusAPI.CicloVidaAtivo.Services
{
    public class AtribuicaoService
    : NexusService<AtribuicaoEnvioDTO, AtribuicaoRespostaDTO, Atribuicao>
    {
        public AtribuicaoService(AtribuicaoRepository repository, TokenService tokenService) : base(repository, tokenService)
        {
        }

        public override AtribuicaoRespostaDTO ConverterParaDTOResposta(Atribuicao obj)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Atribuicao, AtribuicaoRespostaDTO>()
                    .ForMember(c => c.AtualizadoPor, opt => opt.Ignore())
                    .ForMember(c => c.UsuarioCriador, opt => opt.Ignore())
                    .ForMember(c => c.CicloVida, opt => opt.Ignore())
                    .ForMember(c => c.Usuario, opt => opt.Ignore());
            });
            var mapper = new Mapper(config);

            var resposta = mapper.Map<AtribuicaoRespostaDTO>(obj);

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

            resposta.Usuario = new NexusReferenciaObjeto()
            {
                UID = obj.Usuario?.UID,
                Nome = obj.Usuario?.Nome
            };

            resposta.CicloVida = new NexusReferenciaObjeto()
            {
                UID = obj.CicloVida?.UID,
                Nome = obj.CicloVida?.Nome
            };

            return resposta;
        }

        public virtual async Task<List<AtribuicaoRespostaDTO>> ObterTudoPorUsuarioUIDAsync(
            int numeroPagina, string UsuarioUID)
        {
            var atribuicaoRepository = repository as AtribuicaoRepository;

            if (atribuicaoRepository == null)
            {
                throw new Exception("Conversão não sucedida.");
            }

            var objs = await atribuicaoRepository.ObterTudoPorUsuarioUIDAsync(numeroPagina, UsuarioUID);
            var objsResposta = new List<AtribuicaoRespostaDTO>();

            objs.ForEach(o => objsResposta.Add(ConverterParaDTOResposta(o)));

            return objsResposta;
        }
    }
}
