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
        public PerfilService (PerfilRepository repository, TokenService tokenService)
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

        public override PerfilRespostaDTO ConverterParaDTORespostaAsync(Perfil obj)
        {
            var resposta = new PerfilRespostaDTO()
            {
                UID = obj.UID,
                Nome = obj.Nome,
                Descricao = obj.Descricao,

                DataUltimaAtualizacao = obj.DataUltimaAtualizacao,
                AtualizadoPor = new NexusNomeObjeto()
                {
                    UID = obj.AtualizadoPor?.UID,
                    Nome = obj.AtualizadoPor?.Nome
                },

                UsuarioCriador = new NexusNomeObjeto()
                {
                    UID = obj.UsuarioCriador?.UID,
                    Nome = obj.UsuarioCriador?.Nome
                },
                DataCriacao = obj.DataCriacao
            };

            return resposta;
        }
    }
}
