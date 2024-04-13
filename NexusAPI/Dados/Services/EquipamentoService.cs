using AutoMapper;
using NexusAPI.Compartilhado.EntidadesBase.MVC;
using NexusAPI.Compartilhado.EntidadesBase.Objetos;
using NexusAPI.Compartilhado.Services;
using NexusAPI.Dados.DTOs.Componente;
using NexusAPI.Dados.DTOs.Equipamento;
using NexusAPI.Dados.Exceptions;
using NexusAPI.Dados.Models;
using NexusAPI.Dados.Repositories;
using System.Security.Claims;

namespace NexusAPI.Dados.Services
{
    public class EquipamentoService : NexusService<EquipamentoEnvioDTO, EquipamentoRespostaDTO, Equipamento>
    {
        private readonly EquipamentoRepository equipamentoRepository;

        public EquipamentoService(EquipamentoRepository repository, TokenService tokenService) 
        : base(repository, tokenService)
        {
            equipamentoRepository = repository;
        }

        public override EquipamentoRespostaDTO ConverterParaDTOResposta(Equipamento obj)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Equipamento, EquipamentoRespostaDTO>()
                    .ForMember(c => c.AtualizadoPor, opt => opt.Ignore())
                    .ForMember(c => c.UsuarioCriador, opt => opt.Ignore())
                    .ForMember(c => c.Componente, opt => opt.Ignore())
                    .ForMember(c => c.Projeto, opt => opt.Ignore())
                    .ForMember(c => c.Tipo, opt => opt.Ignore());
            });
            var mapper = new Mapper(config);

            var resposta = mapper.Map<EquipamentoRespostaDTO>(obj);

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

            resposta.Componente = new NexusReferenciaObjeto()
            {
                UID = obj.Componente?.UID,
                Nome = obj.Componente?.Nome,
            };

            resposta.Projeto = new NexusReferenciaObjeto()
            {
                UID = obj.Projeto?.UID,
                Nome = obj.Projeto?.Nome,
            };

            resposta.Tipo = new NexusReferenciaObjeto()
            {
                UID = ((int)obj.Tipo).ToString(),
                Nome = NexusManipulacaoEnum.ObterDescricao(obj.Tipo),
            };

            return resposta;
        }

        public override async Task<EquipamentoRespostaDTO> AdicionarAsync(EquipamentoEnvioDTO obj, IEnumerable<Claim> claims)
        {
            var objClasse = ConverterParaClasse(obj);

            if (await equipamentoRepository.ObterPorNumeroSerieAsync(objClasse.NumeroSerie) != null)
            {
                throw new NumeroSerieJaCadastrado();
            }

            objClasse.UID = Guid.NewGuid().ToString();
            objClasse.UsuarioCriadorUID = tokenService.ObterUsuarioUID(claims);

            var UID = (await repository.AdicionarAsync(objClasse)).UID;

            var objAposSerCriado = await repository.ObterPorUIDAsync(UID);

            if (objAposSerCriado == null)
            {
                throw new Exception("Objeto atualizado não foi encontrado.");
            }

            return ConverterParaDTOResposta(objAposSerCriado);
        }
    }
}
