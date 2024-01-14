using NexusAPI.Administracao.DTOs.Projeto;
using NexusAPI.Administracao.DTOs.Usuario;
using NexusAPI.Administracao.Models;
using NexusAPI.Administracao.Repositories;
using NexusAPI.Compartilhado.EntidadesBase;
using NexusAPI.Compartilhado.Services;

namespace NexusAPI.Administracao.Services
{
    public class ProjetoService : NexusService<ProjetoEnvioDTO, ProjetoRespostaDTO, Projeto>
    {
        public ProjetoService(
            ProjetoRepository repository, TokenService tokenService, UsuariosService usuarioService) 
        : base(repository, tokenService, usuarioService) { }

        public override Projeto ConverterParaClasse(ProjetoEnvioDTO obj)
        {
            var resposta = new Projeto()
            {
                Nome = obj.Nome,
                Descricao = obj.Descricao
            };

            return resposta;
        }

        public async override Task<ProjetoRespostaDTO> ConverterParaDTORespostaAsync(Projeto obj)
        {
            if (usuarioService == null)
            {
                throw new Exception("A instância da classe de serviço não pode ser nula.");
            }

            var resposta = new ProjetoRespostaDTO()
            {
                UID = obj.UID,
                Nome = obj.Nome,
                Descricao = obj.Descricao,

                DataUltimaAtualizacao = obj.DataUltimaAtualizacao,
                AtualizadoPor = new NexusNomeObjeto()
                {
                    UID = obj.AtualizadoPorUID,
                    Nome = obj.AtualizadoPorUID != null ?
                        await usuarioService.ObterNomePorUIDAsync(obj.AtualizadoPorUID) : null
                },

                UsuarioCriador = new NexusNomeObjeto()
                {
                    UID = obj.UsuarioCriadorUID,
                    Nome = obj.UsuarioCriadorUID != null ?
                        await usuarioService.ObterNomePorUIDAsync(obj.UsuarioCriadorUID) : null
                },
                DataCriacao = obj.DataCriacao
            };

            return resposta;
        }
    }
}
