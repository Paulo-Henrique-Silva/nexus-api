using AutoMapper;
using NexusAPI.Administracao.DTOs.UsuarioPerfil;
using NexusAPI.Compartilhado.EntidadesBase;
using NexusAPI.Compartilhado.Services;
using NexusAPI.Dados.DTOs.Componente;
using NexusAPI.Dados.DTOs.Localizacao;
using NexusAPI.Dados.Enums;
using NexusAPI.Dados.Models;
using NexusAPI.Dados.Repositories;

namespace NexusAPI.Dados.Services
{
    public class ComponenteService : NexusService<ComponenteEnvioDTO, ComponenteRespostaDTO, Componente>
    {
        public ComponenteService(ComponenteRepository repository, TokenService tokenService) 
        : base(repository, tokenService)
        {
        }

        public override ComponenteRespostaDTO ConverterParaDTORespostaAsync(Componente obj)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Componente, ComponenteRespostaDTO>()
                    .ForMember(c => c.AtualizadoPor, opt => opt.Ignore())
                    .ForMember(c => c.UsuarioCriador, opt => opt.Ignore())
                    .ForMember(c => c.Localizacao, opt => opt.Ignore());
            });
            var mapper = new Mapper(config);

            var resposta = mapper.Map<ComponenteRespostaDTO>(obj);

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

            resposta.Localizacao = new NexusNomeObjeto()
            {
                UID = obj.Localizacao?.UID,
                Nome = obj.Localizacao?.Nome,
            };

            resposta.Projeto = new NexusNomeObjeto()
            {
                UID = obj.Projeto?.UID,
                Nome = obj.Projeto?.Nome,
            };

            return resposta;
        }
    }
}
