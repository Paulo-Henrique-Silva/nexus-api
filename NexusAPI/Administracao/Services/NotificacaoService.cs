using NexusAPI.Administracao.DTOs.Notificacao;
using NexusAPI.Administracao.DTOs.Usuario;
using NexusAPI.Administracao.Models;
using NexusAPI.Administracao.Repositories;
using NexusAPI.Compartilhado.EntidadesBase;

namespace NexusAPI.Administracao.Services
{
    public class NotificacaoService : NexusService<NotificacaoEnvioDTO, NotificacaoRespostaDTO, Notificacao>
    {
        public NotificacaoService(NotificacaoRepository repository) : base(repository)
        {
        }

        public override Notificacao ConverterParaClasse(NotificacaoEnvioDTO obj)
        {
            var resposta = new Notificacao()
            {
                Nome = obj.Nome ?? "",
                Descricao = obj.Descricao ?? "",
                UsuarioUID = obj.UsuarioUID ?? ""
            };

            return resposta;
        }

        public async override Task<NotificacaoRespostaDTO> ConverterParaDTORespostaAsync(Notificacao obj)
        {
            var resposta = new NotificacaoRespostaDTO()
            {
                UID = obj.UID,
                Nome = obj.Nome,
                Descricao = obj.Descricao,
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
