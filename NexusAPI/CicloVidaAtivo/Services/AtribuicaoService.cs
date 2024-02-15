using AutoMapper;
using NexusAPI.Administracao.DTOs.Notificacao;
using NexusAPI.Administracao.Repositories;
using NexusAPI.CicloVidaAtivo.DTOs.Atribuicao;
using NexusAPI.CicloVidaAtivo.Enums;
using NexusAPI.CicloVidaAtivo.Models;
using NexusAPI.CicloVidaAtivo.Repositories;
using NexusAPI.Compartilhado.EntidadesBase.DTOs;
using NexusAPI.Compartilhado.EntidadesBase.MVC;
using NexusAPI.Compartilhado.EntidadesBase.Objetos;
using NexusAPI.Compartilhado.Exceptions;
using NexusAPI.Compartilhado.Services;
using NexusAPI.Dados.Services;

namespace NexusAPI.CicloVidaAtivo.Services
{
    public class AtribuicaoService : NexusService<AtribuicaoEnvioDTO, AtribuicaoRespostaDTO, Atribuicao>
    {
        private readonly ManutencaoService manutencaoService;

        private readonly RequisicaoService requisicaoService;

        public AtribuicaoService(
            AtribuicaoRepository repository, 
            ManutencaoService manutencaoService, 
            RequisicaoService requisicaoService,
            TokenService tokenService) 
        : base(repository, tokenService)
        {
            this.manutencaoService = manutencaoService;
            this.requisicaoService = requisicaoService;
        }

        public override AtribuicaoRespostaDTO ConverterParaDTOResposta(Atribuicao obj)
        {
            return ConverterParaDTORespostaAsync(obj).Result;
        }

        /// <summary>
        /// Método async usário apenas para manter a implementação da interface.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public async Task<AtribuicaoRespostaDTO> ConverterParaDTORespostaAsync(Atribuicao obj)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Atribuicao, AtribuicaoRespostaDTO>()
                    .ForMember(c => c.AtualizadoPor, opt => opt.Ignore())
                    .ForMember(c => c.UsuarioCriador, opt => opt.Ignore())
                    .ForMember(c => c.Usuario, opt => opt.Ignore())
                    .ForMember(c => c.Tipo, opt => opt.Ignore())
                    .ForMember(c => c.Objeto, opt => opt.Ignore())
                    .ForMember(c => c.Projeto, opt => opt.Ignore());
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

            //Obtém nome e UID da atribuição
            var objetoCiclo = await ObterNomeObjetoPorCicloUID(obj.ObjetoUID, obj.Tipo);
            resposta.Objeto = objetoCiclo;

            resposta.Tipo = new NexusReferenciaObjeto()
            {
                UID = ((int)obj.Tipo).ToString(),
                Nome = NexusManipulacaoEnum.ObterDescricao(obj.Tipo)
            };

            resposta.Projeto = new NexusReferenciaObjeto()
            {
                UID = obj.Projeto?.UID,
                Nome = obj.Projeto?.Nome
            };

            return resposta;
        }

        /// <summary>
        /// Obtém atribuições pelo usuário UID.
        /// </summary>
        /// <param name="usuarioUID"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public virtual async Task<NexusListaRespostaDTO<AtribuicaoRespostaDTO>> ObterTudoPorUsuarioUIDAsync(string usuarioUID)
        {
            var atribuicaoRepository = repository as AtribuicaoRepository;

            if (atribuicaoRepository == null)
            {
                throw new Exception("Conversão não sucedida.");
            }

            var objs = await atribuicaoRepository.ObterTudoPorUsuarioUIDAsync(usuarioUID);
            var objsResposta = new List<AtribuicaoRespostaDTO>();

            objs.ForEach(o => objsResposta.Add(ConverterParaDTOResposta(o)));

            var resposta = new NexusListaRespostaDTO<AtribuicaoRespostaDTO>()
            {
                TotalItens = await repository.ObterCountAsync(),
                Itens = objsResposta
            };

            return resposta;
        }


        /// <summary>
        /// Retorna a referência de objeto que está em ciclo de vida.
        /// </summary>
        /// <param name="UID"></param>
        /// <param name="tipo"></param>
        /// <returns></returns>
        /// <exception cref="ObjetoNaoEncontrado"></exception>
        private async Task<NexusReferenciaObjeto> ObterNomeObjetoPorCicloUID(string UID, TipoAtribuicao tipo)
        {
            //Busca ciclo de vida.
            var objeto = new NexusReferenciaObjeto();

            //Obtém o objeto conforme tipo da atribuição.
            if (tipo == TipoAtribuicao.CompletarManutencao)
            {
                var manutencao = await manutencaoService.ObterPorUIDAsync(UID);

                objeto.UID = manutencao.UID;
                objeto.Nome = manutencao.Nome;
            }
            else
            {
                var requisicao = await requisicaoService.ObterPorUIDAsync(UID);

                objeto.UID = requisicao.UID;
                objeto.Nome = requisicao.Nome;
            }

            return objeto;
        }
    }
}
