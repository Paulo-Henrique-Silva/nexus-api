using NexusAPI.Administracao.DTOs.Notificacao;
using NexusAPI.Administracao.DTOs.Usuario;
using NexusAPI.Administracao.Models;
using NexusAPI.Administracao.Repositories;
using NexusAPI.Compartilhado.EntidadesBase;
using NexusAPI.Compartilhado.Services;

namespace NexusAPI.Administracao.Services
{
    public class NotificacaoService 
    : NexusService<NotificacaoEnvioDTO, NotificacaoRespostaDTO, Notificacao>
    {
        public NotificacaoService(
            NotificacaoRepository repository, TokenService tokenService) 
        : base(repository, tokenService) { }

        public override Notificacao ConverterParaClasse(NotificacaoEnvioDTO obj)
        {
            var resposta = new Notificacao()
            {
                Nome = obj.Nome,
                Descricao = obj.Descricao,
                UsuarioUID = obj.UsuarioUID
            };

            return resposta;
        }

        public override NotificacaoRespostaDTO ConverterParaDTORespostaAsync(Notificacao obj)
        {
            var resposta = new NotificacaoRespostaDTO()
            {
                UID = obj.UID,
                Nome = obj.Nome,
                Descricao = obj.Descricao,
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
                DataCriacao = obj.DataCriacao,
                Usuario = new NexusNomeObjeto()
                {
                    UID = obj.Usuario?.UID,
                    Nome = obj.Usuario?.Nome
                }
            };

            return resposta;
        }
    }
}
