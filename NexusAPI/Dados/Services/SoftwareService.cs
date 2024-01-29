using AutoMapper;
using NexusAPI.Compartilhado.EntidadesBase.MVC;
using NexusAPI.Compartilhado.EntidadesBase.Objetos;
using NexusAPI.Compartilhado.Services;
using NexusAPI.Dados.DTOs.Manutencao;
using NexusAPI.Dados.DTOs.Requisicao;
using NexusAPI.Dados.DTOs.Software;
using NexusAPI.Dados.Models;
using NexusAPI.Dados.Repositories;

namespace NexusAPI.Dados.Services
{
    public class SoftwareService : NexusService<SoftwareEnvioDTO, SoftwareRespostaDTO, Software>
    {
        public SoftwareService(SoftwareRepository repository, TokenService tokenService) 
        : base(repository, tokenService)
        {
        }

        public override SoftwareRespostaDTO ConverterParaDTOResposta(Software obj)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Software, SoftwareRespostaDTO>()
                    .ForMember(c => c.AtualizadoPor, opt => opt.Ignore())
                    .ForMember(c => c.UsuarioCriador, opt => opt.Ignore())
                    .ForMember(c => c.Componente, opt => opt.Ignore());
            });
            var mapper = new Mapper(config);

            var resposta = mapper.Map<SoftwareRespostaDTO>(obj);

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

            resposta.Projeto = new NexusNomeObjeto()
            {
                UID = obj.Projeto?.UID,
                Nome = obj.Projeto?.Nome,
            };

            return resposta;
        }
    }
}
