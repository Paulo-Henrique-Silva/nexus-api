using AutoMapper;
using NexusAPI.Compartilhado.EntidadesBase;
using NexusAPI.Compartilhado.Services;
using NexusAPI.Dados.DTOs.Componente;
using NexusAPI.Dados.DTOs.Equipamento;
using NexusAPI.Dados.Models;
using NexusAPI.Dados.Repositories;

namespace NexusAPI.Dados.Services
{
    public class EquipamentoService
    : NexusService<EquipamentoEnvioDTO, EquipamentoRespostaDTO, Equipamento>
    {
        public EquipamentoService(EquipamentoRepository repository, TokenService tokenService) 
        : base(repository, tokenService)
        {
        }

        public override EquipamentoRespostaDTO ConverterParaDTORespostaAsync(Equipamento obj)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Equipamento, EquipamentoRespostaDTO>()
                    .ForMember(c => c.AtualizadoPor, opt => opt.Ignore())
                    .ForMember(c => c.UsuarioCriador, opt => opt.Ignore())
                    .ForMember(c => c.Localizacao, opt => opt.Ignore())
                    .ForMember(c => c.Componente, opt => opt.Ignore());
            });
            var mapper = new Mapper(config);

            var resposta = mapper.Map<EquipamentoRespostaDTO>(obj);

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
