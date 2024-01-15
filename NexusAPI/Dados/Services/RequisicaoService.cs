using AutoMapper;
using NexusAPI.Compartilhado.EntidadesBase;
using NexusAPI.Compartilhado.Services;
using NexusAPI.Dados.DTOs.Manutencao;
using NexusAPI.Dados.DTOs.Requisicao;
using NexusAPI.Dados.Models;

namespace NexusAPI.Dados.Services
{
    public class RequisicaoService
    : NexusService<RequisicaoEnvioDTO, RequisicaoRespostaDTO, Requisicao>
    {
        public RequisicaoService(NexusRepository<Requisicao> repository, TokenService tokenService) : base(repository, tokenService)
        {
        }

        public override RequisicaoRespostaDTO ConverterParaDTORespostaAsync(Requisicao obj)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Requisicao, RequisicaoRespostaDTO>()
                    .ForMember(c => c.AtualizadoPor, opt => opt.Ignore())
                    .ForMember(c => c.UsuarioCriador, opt => opt.Ignore())
                    .ForMember(c => c.Coordenador, opt => opt.Ignore());
            });
            var mapper = new Mapper(config);

            var resposta = mapper.Map<RequisicaoRespostaDTO>(obj);

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

            resposta.Coordenador = new NexusNomeObjeto()
            {
                UID = obj.Coordenador?.UID,
                Nome = obj.Coordenador?.Nome,
            };

            return resposta;
        }
    }
}
