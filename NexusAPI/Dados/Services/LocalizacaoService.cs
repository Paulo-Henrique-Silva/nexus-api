using AutoMapper;
using NexusAPI.Administracao.DTOs.Perfil;
using NexusAPI.Administracao.DTOs.Projeto;
using NexusAPI.Administracao.Models;
using NexusAPI.Compartilhado.EntidadesBase;
using NexusAPI.Compartilhado.Services;
using NexusAPI.Dados.DTOs.Localizacao;
using NexusAPI.Dados.Models;

namespace NexusAPI.Dados.Services
{
    public class LocalizacaoService
    : NexusService<LocalizacaoEnvioDTO, LocalizacaoRespostaDTO, Localizacao>
    {
        public LocalizacaoService(NexusRepository<Localizacao> repository, TokenService tokenService) 
        : base(repository, tokenService)
        {
        }

        public override LocalizacaoRespostaDTO ConverterParaDTORespostaAsync(Localizacao obj)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Localizacao, LocalizacaoRespostaDTO>()
                    .ForMember(c => c.AtualizadoPor, opt => opt.Ignore())
                    .ForMember(c => c.UsuarioCriador, opt => opt.Ignore());
            });
            var mapper = new Mapper(config);

            var resposta = mapper.Map<LocalizacaoRespostaDTO>(obj);

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
