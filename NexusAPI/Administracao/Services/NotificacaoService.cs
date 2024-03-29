﻿using AutoMapper;
using NexusAPI.Administracao.DTOs.Notificacao;
using NexusAPI.Administracao.DTOs.Usuario;
using NexusAPI.Administracao.Models;
using NexusAPI.Administracao.Repositories;
using NexusAPI.CicloVidaAtivo.DTOs.Atribuicao;
using NexusAPI.Compartilhado.EntidadesBase.DTOs;
using NexusAPI.Compartilhado.EntidadesBase.MVC;
using NexusAPI.Compartilhado.EntidadesBase.Objetos;
using NexusAPI.Compartilhado.Services;

namespace NexusAPI.Administracao.Services
{
    public class NotificacaoService 
    : NexusService<NotificacaoEnvioDTO, NotificacaoRespostaDTO, Notificacao>
    {
        public NotificacaoService(
            NotificacaoRepository repository, TokenService tokenService) 
        : base(repository, tokenService) { }

        public override NotificacaoRespostaDTO ConverterParaDTOResposta(Notificacao obj)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Notificacao, NotificacaoRespostaDTO>()
                    .ForMember(c => c.AtualizadoPor, opt => opt.Ignore())
                    .ForMember(c => c.UsuarioCriador, opt => opt.Ignore())
                    .ForMember(c => c.Usuario, opt => opt.Ignore());
            });
            var mapper = new Mapper(config);

            var resposta = mapper.Map<NotificacaoRespostaDTO>(obj);

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

            return resposta;
        }

        /// <summary>
        /// Retorna a lista de notificações por usuárioUID. Não possui paginação para facilitar desenvolvimento.
        /// </summary>
        /// <param name="UsuarioUID"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public virtual async Task<NexusListaRespostaDTO<NotificacaoRespostaDTO>> ObterTudoPorUsuarioUIDAsync(string UsuarioUID)
        {
            var notificacaoRepository = repository as NotificacaoRepository;

            if (notificacaoRepository == null)
            {
                throw new Exception("Conversão não sucedida.");
            }

            var objs = await notificacaoRepository.ObterTudoPorUsuarioUIDAsync(UsuarioUID);
            var objsResposta = new List<NotificacaoRespostaDTO>();

            objs.ForEach(o => objsResposta.Add(ConverterParaDTOResposta(o)));

            var resposta = new NexusListaRespostaDTO<NotificacaoRespostaDTO>()
            {
                TotalItens = await repository.ObterCountAsync(),
                Itens = objsResposta
            };

            return resposta;
        }
    }
}
