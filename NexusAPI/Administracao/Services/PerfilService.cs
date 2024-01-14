using NexusAPI.Administracao.DTOs.Perfil;
using NexusAPI.Administracao.DTOs.Projeto;
using NexusAPI.Administracao.Models;
using NexusAPI.Administracao.Repositories;
using NexusAPI.Compartilhado.EntidadesBase;
using NexusAPI.Compartilhado.Services;

namespace NexusAPI.Administracao.Services
{
    public class PerfilService : NexusService<PerfilEnvioDTO, PerfilRespostaDTO, Perfil>
    {
        public PerfilService
            (PerfilRepository repository, TokenService tokenService, UsuariosService usuarioService)
        : base(repository, tokenService, usuarioService) { }

        public override Perfil ConverterParaClasse(PerfilEnvioDTO obj)
        {
            var resposta = new Perfil()
            {
                Nome = obj.Nome,
                Descricao = obj.Descricao
            };

            return resposta;
        }

        public async override Task<PerfilRespostaDTO> ConverterParaDTORespostaAsync(Perfil obj)
        {
            if (usuarioService == null)
            {
                throw new Exception("A instância da classe de serviço não pode ser nula.");
            }

            var resposta = new PerfilRespostaDTO()
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
