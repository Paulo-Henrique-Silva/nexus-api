using AutoMapper;
using NexusAPI.Administracao.Models;
using NexusAPI.Compartilhado.EntidadesBase;
using NexusAPI.Compartilhado.Services;
using NexusAPI.Dados.DTOs.Componente;
using NexusAPI.Dados.DTOs.Manutencao;
using NexusAPI.Dados.Models;

namespace NexusAPI.Dados.Services
{
    public class ManutencaoService : NexusService<ManutencaoEnvioDTO, ManutencaoRespostaDTO, Manutencao>
    {
        public ManutencaoService(NexusRepository<Manutencao> repository, TokenService tokenService) 
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
                    .ForMember(c => c.Componente, opt => opt.Ignore());
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

            return resposta;
        }
    }
}
