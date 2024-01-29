using AutoMapper;
using NexusAPI.Administracao.DTOs.Perfil;
using NexusAPI.Administracao.DTOs.Projeto;
using NexusAPI.Administracao.Models;
using NexusAPI.Compartilhado.EntidadesBase.MVC;
using NexusAPI.Compartilhado.Services;
using NexusAPI.Dados.DTOs.Equipamento;
using NexusAPI.Dados.DTOs.Localizacao;
using NexusAPI.Dados.Models;
using NexusAPI.Dados.Repositories;

namespace NexusAPI.Dados.Services
{
    public class LocalizacaoService
    : NexusService<LocalizacaoEnvioDTO, LocalizacaoRespostaDTO, Localizacao>
    {
        public LocalizacaoService(LocalizacaoRepository repository, TokenService tokenService) 
        : base(repository, tokenService)
        {
        }

        public override LocalizacaoRespostaDTO ConverterParaDTOResposta(Localizacao obj)
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

            resposta.Projeto = new NexusNomeObjeto()
            {
                UID = obj.Projeto?.UID,
                Nome = obj.Projeto?.Nome,
            };

            return resposta;
        }

        public async Task<List<LocalizacaoRespostaDTO>> ObterTudoPorProjetoUIDAsync(int numeroPagina,
            string projetoUID)
        {
            var localizacaoRepository = repository as LocalizacaoRepository;

            if (localizacaoRepository == null)
            {
                throw new Exception("Instância incorreta em repository.");
            }

            var objs = await localizacaoRepository.ObterTudoPorProjetoUIDAsync(numeroPagina, projetoUID);
            var objsResposta = new List<LocalizacaoRespostaDTO>();

            objs.ForEach(o => objsResposta.Add(ConverterParaDTOResposta(o)));

            return objsResposta;
        }
    }
}
