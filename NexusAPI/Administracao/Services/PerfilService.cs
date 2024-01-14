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
        public PerfilService(PerfilRepository repository, TokenService tokenService)
        : base(repository, tokenService) { }

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
                        await ObterNomePorUIDAsync(obj.AtualizadoPorUID) : null
                },

                UsuarioCriador = new NexusNomeObjeto()
                {
                    UID = obj.UsuarioCriadorUID,
                    Nome = obj.UsuarioCriadorUID != null ?
                        await ObterNomePorUIDAsync(obj.UsuarioCriadorUID) : null
                },
                DataCriacao = obj.DataCriacao
            };

            return resposta;
        }
    }
}
