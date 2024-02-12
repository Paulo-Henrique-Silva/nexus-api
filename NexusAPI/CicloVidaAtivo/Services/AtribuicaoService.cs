using AutoMapper;
using NexusAPI.Administracao.DTOs.Notificacao;
using NexusAPI.Administracao.Repositories;
using NexusAPI.CicloVidaAtivo.DTOs.Atribuicao;
using NexusAPI.CicloVidaAtivo.Models;
using NexusAPI.CicloVidaAtivo.Repositories;
using NexusAPI.Compartilhado.EntidadesBase.DTOs;
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
                    .ForMember(c => c.Usuario, opt => opt.Ignore())
                    .ForMember(c => c.Tipo, opt => opt.Ignore());
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

            resposta.Tipo = new NexusReferenciaObjeto()
            {
                UID = ((int)obj.Tipo).ToString(),
                Nome = NexusManipulacaoEnum.ObterDescricao(obj.Tipo)
            };

            return resposta;
        }

        public virtual async Task<NexusListaRespostaDTO<AtribuicaoRespostaDTO>> ObterTudoPorUsuarioUIDAsync(
            int numeroPagina, string UsuarioUID)
        {
            var atribuicaoRepository = repository as AtribuicaoRepository;

            if (atribuicaoRepository == null)
            {
                throw new Exception("Conversão não sucedida.");
            }

            var objs = await atribuicaoRepository.ObterTudoAsync(numeroPagina);
            var objsResposta = new List<AtribuicaoRespostaDTO>();

            objs.ForEach(o => objsResposta.Add(ConverterParaDTOResposta(o)));

            var resposta = new NexusListaRespostaDTO<AtribuicaoRespostaDTO>()
            {
                TotalItens = await repository.ObterCountAsync(),
                Itens = objsResposta
            };

            return resposta;
        }
    }
}
