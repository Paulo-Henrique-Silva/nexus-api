using AutoMapper;
using NexusAPI.Administracao.DTOs.Perfil;
using NexusAPI.Administracao.DTOs.Projeto;
using NexusAPI.Administracao.DTOs.Usuario;
using NexusAPI.Administracao.Models;
using NexusAPI.Administracao.Repositories;
using NexusAPI.Compartilhado.EntidadesBase.MVC;
using NexusAPI.Compartilhado.Services;

namespace NexusAPI.Administracao.Services
{
    public class ProjetoService : NexusService<ProjetoEnvioDTO, ProjetoRespostaDTO, Projeto>
    {
        public ProjetoService(ProjetoRepository repository, TokenService tokenService) 
        : base(repository, tokenService) { }

        public override ProjetoRespostaDTO ConverterParaDTOResposta(Projeto obj)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Projeto, ProjetoRespostaDTO>()
                    .ForMember(c => c.AtualizadoPor, opt => opt.Ignore())
                    .ForMember(c => c.UsuarioCriador, opt => opt.Ignore());
            });
            var mapper = new Mapper(config);

            var resposta = mapper.Map<ProjetoRespostaDTO>(obj);

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
