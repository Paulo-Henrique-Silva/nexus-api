using NexusAPI.Administracao.DTOs;
using NexusAPI.Administracao.Models;
using NexusAPI.Administracao.Repositories;
using NexusAPI.Compartilhado.EntidadesBase;
using NexusAPI.Compartilhado.Exceptions;

namespace NexusAPI.Administracao.Services
{
    public class UsuariosService : BaseService<UsuarioEnvioDTO, UsuarioRespostaDTO, Usuario>
    {
        public UsuariosService(UsuarioRepository repository) : base(repository)
        {

        }

        public override Usuario ConverterParaClasse(UsuarioEnvioDTO obj)
        {
            var resposta = new Usuario()
            {
                NomeAcesso = obj.NomeAcesso,
                UID = obj.UID,
                Senha = obj.Senha
            };

            return resposta;
        }

        public override async Task<UsuarioRespostaDTO> ConverterParaDTOResposta(Usuario obj)
        {
            var resposta = new UsuarioRespostaDTO()
            {
                NomeAcesso = obj.NomeAcesso,
                UID = obj.UID,
                Nome = obj.Nome,
                Descricao = obj.Descricao,
                AtualizadoPor = new BaseObjetoResposta() 
                { 
                    UID = obj.AtualizadoPorUID, 
                    Nome = obj.AtualizadoPorUID != null ? await ObterNomePorUID(obj.AtualizadoPorUID) : null 
                },
                UsuarioCriador = new BaseObjetoResposta()
                {
                    UID = obj.UsuarioCriadorUID,
                    Nome = obj.UsuarioCriadorUID != null ? await ObterNomePorUID(obj.UsuarioCriadorUID) : null
                }
            };

            return resposta;
        }
    }
}
