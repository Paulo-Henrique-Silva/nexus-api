using AutoMapper;
using NexusAPI.CicloVidaAtivo.DTOs.CicloVida;
using NexusAPI.CicloVidaAtivo.DTOs.CicloVidaPasso;
using NexusAPI.CicloVidaAtivo.Models;
using NexusAPI.CicloVidaAtivo.Repositories;
using NexusAPI.Compartilhado.EntidadesBase;
using NexusAPI.Compartilhado.Services;

namespace NexusAPI.CicloVidaAtivo.Services
{
    public class CicloVidaPassoService
    : NexusService<CicloVidaPassoEnvioDTO, CicloVidaPassoRespostaDTO, CicloVidaPasso>
    {
        public CicloVidaPassoService(CicloVidaPassoRepository repository, TokenService tokenService) 
        : base(repository, tokenService)
        {
        }

        public override CicloVidaPassoRespostaDTO ConverterParaDTORespostaAsync(CicloVidaPasso obj)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CicloVidaPasso, CicloVidaPassoRespostaDTO>()
                    .ForMember(c => c.AtualizadoPor, opt => opt.Ignore())
                    .ForMember(c => c.UsuarioCriador, opt => opt.Ignore());
            });
            var mapper = new Mapper(config);

            var resposta = mapper.Map<CicloVidaPassoRespostaDTO>(obj);

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

            resposta.CicloVida = new NexusNomeObjeto()
            {
                UID = obj.CicloVida?.UID,
                Nome = obj.CicloVida?.Nome
            };

            resposta.PassoFalha = new NexusNomeObjeto()
            {
                UID = obj.PassoFalha?.UID,
                Nome = obj.PassoFalha?.Nome
            };

            resposta.PassoSucesso = new NexusNomeObjeto()
            {
                UID = obj.PassoSucesso?.UID,
                Nome = obj.PassoSucesso?.Nome
            };

            return resposta;
        }
    }
}
