using NexusAPI.Administracao.DTOs.Notificacao;
using NexusAPI.Administracao.Services;
using NexusAPI.CicloVidaAtivo.DTOs.Atribuicao;
using NexusAPI.CicloVidaAtivo.DTOs.CicloVida;
using NexusAPI.CicloVidaAtivo.Enums;
using NexusAPI.Compartilhado.EntidadesBase.CicloVida;
using NexusAPI.Compartilhado.Exceptions;
using NexusAPI.Compartilhado.Services;
using NexusAPI.Dados.Services;
using System.Security.Claims;

namespace NexusAPI.CicloVidaAtivo.Services
{
    /// <summary>
    /// Uma requisição de novo equipamento é feita por um usuário de Suporte, que indica o coordernador responsável. 
    /// O coordernador aprova ou rejeita. 
    /// Uma notificação é gerada em caso de aprovação ou rejeição. 
    /// Se aprovada, o coordenador deverá completar após o equipamento for adquirido.
    /// </summary>
    public class AnaliseRequisicaoService : NexusCicloVidaService
    {
        private readonly RequisicaoService requisicaoService;

        public AnaliseRequisicaoService(
            AtribuicaoService atribuicaoService,
            RequisicaoService requisicaoService,
            NotificacaoService notificacaoService,
            TokenService tokenService) 
        : base(atribuicaoService, notificacaoService, tokenService)
        {
            this.requisicaoService = requisicaoService;
        }

        public override async Task IniciarCiclovida(CicloVidaIniciarDTO envio, IEnumerable<Claim> claims)
        {
            await AnaliseCoordenador(envio.ObjetoUID, claims);
        }

        public async Task AnaliseCoordenador(string requisicaoUID, IEnumerable<Claim> claims)
        {
            var requisicao = await requisicaoService.ObterPorUIDAsync(requisicaoUID);

            //Cria uma nova atribuição para o usuário.
            var atribuicao = new AtribuicaoEnvioDTO()
            {
                Nome = "Análise de Requisição",
                Descricao = "Verifique os detalhes da requisição. Logo após, por favor, aprove ou rejeite o pedido " +
                "utilizando as opções disponíveis.",
                UsuarioUID = requisicao.Coordenador.UID,
                Tipo = TipoAtribuicao.AnaliseRequisicao,
                DataVencimento = ObterDataDiasUteis(3),
                Concluida = false,
                ObjetoUID = requisicaoUID,
                ProjetoUID = requisicao.Projeto.UID
            };

            await atribuicaoService.AdicionarAsync(atribuicao, claims);
        }

        public async Task CoordenadorAprovou(CicloVidaResponderDTO envio, IEnumerable<Claim> claims)
        {
            //Obtém a atribuição de análise.
            var atribuicao = await atribuicaoService.ObterPorUIDAsync(envio.AtribuicaoUID);

            if (atribuicao == null)
            {
                throw new ObjetoNaoEncontrado(envio.AtribuicaoUID);
            }

            //edita-a para deixar como concluida.
            var atribuicaoAnalise = new AtribuicaoEnvioDTO()
            {
                Nome = atribuicao.Nome,
                Descricao = atribuicao.Descricao,
                UsuarioUID = atribuicao.Usuario.UID,
                Tipo = (TipoAtribuicao)Enum.Parse(typeof(TipoAtribuicao), atribuicao.Tipo.UID),
                DataVencimento = atribuicao.DataVencimento,
                Concluida = true, //seta como true.
                ObjetoUID = atribuicao.Objeto.UID,
                ProjetoUID = atribuicao.Projeto.UID
            };

            await atribuicaoService.EditarAsync(envio.AtribuicaoUID, atribuicaoAnalise, claims);

            //cria nova atribuição para concluir requisição.
            var requisicao = await requisicaoService.ObterPorUIDAsync(atribuicao.Objeto.UID);
            var atribuicaoConcluir = new AtribuicaoEnvioDTO()
            {
                Nome = "Concluir requisição",
                Descricao = $"A requisição {requisicao.Nome} foi aprovada. Você terá 5 dias para implantá-la e marcar como concluída. " +
                $"Por favor, utilize a opção disponível para deixar registrado.",
                UsuarioUID = atribuicao.Usuario.UID,
                Tipo = TipoAtribuicao.CompletarRequisicao,
                DataVencimento = ObterDataDiasUteis(5),
                Concluida = false,
                ObjetoUID = atribuicao.Objeto.UID,
                ProjetoUID = atribuicao.Projeto.UID
            };

            await atribuicaoService.AdicionarAsync(atribuicaoConcluir, claims);

            //gera notificação
            var notificacao = new NotificacaoEnvioDTO()
            {
                Nome = $"Requisição {requisicao.Nome} aprovada.",
                Descricao = $"O Coordenador {requisicao.Coordenador.Nome} aprovou a requisição {requisicao.Nome}. " +
                $"Dentro de 5 dias úteis o pedido será concluído e implantado.",
                UsuarioUID = requisicao.UsuarioCriador.UID,
                Vista = false
            };

            await notificacaoService.AdicionarAsync(notificacao, claims);
        }

        public async Task CoordenadorReprovou(CicloVidaResponderDTO envio, IEnumerable<Claim> claims)
        {
            //Obtém a atribuição em questão
            var atribuicao = await atribuicaoService.ObterPorUIDAsync(envio.AtribuicaoUID);

            if (atribuicao == null)
            {
                throw new ObjetoNaoEncontrado(envio.AtribuicaoUID);
            }

            //edita-a para deixar como concluida.
            var atribuicaoEnvio = new AtribuicaoEnvioDTO()
            {
                Nome = atribuicao.Nome,
                Descricao = atribuicao.Descricao,
                UsuarioUID = atribuicao.Usuario.UID,
                Tipo = (TipoAtribuicao)Enum.Parse(typeof(TipoAtribuicao), atribuicao.Tipo.UID),
                DataVencimento = atribuicao.DataVencimento,
                Concluida = true, //seta como true.
                ObjetoUID = atribuicao.Objeto.UID,
                ProjetoUID = atribuicao.Projeto.UID
            };

            await atribuicaoService.EditarAsync(envio.AtribuicaoUID, atribuicaoEnvio, claims);

            //gera notificação
            var requisicao = await requisicaoService.ObterPorUIDAsync(atribuicao.Objeto.UID);

            var notificacao = new NotificacaoEnvioDTO()
            {
                Nome = $"Requisição {requisicao.Nome} reprovada.",
                Descricao = $"O Coordenador {requisicao.Coordenador.Nome} reprovou a requisição {requisicao.Nome}.",
                UsuarioUID = requisicao.UsuarioCriador.UID,
                Vista = false
            };

            await notificacaoService.AdicionarAsync(notificacao, claims);
        }

        public async Task CoordenadorCompletou(CicloVidaResponderDTO envio, IEnumerable<Claim> claims)
        {
            //Obtém a atribuição em questão
            var atribuicao = await atribuicaoService.ObterPorUIDAsync(envio.AtribuicaoUID);

            if (atribuicao == null)
            {
                throw new ObjetoNaoEncontrado(envio.AtribuicaoUID);
            }

            //edita-a para deixar como concluida.
            var atribuicaoEnvio = new AtribuicaoEnvioDTO()
            {
                Nome = atribuicao.Nome,
                Descricao = atribuicao.Descricao,
                UsuarioUID = atribuicao.Usuario.UID,
                Tipo = (TipoAtribuicao)Enum.Parse(typeof(TipoAtribuicao), atribuicao.Tipo.UID),
                DataVencimento = atribuicao.DataVencimento,
                Concluida = true, //seta como true.
                ObjetoUID = atribuicao.Objeto.UID,
                ProjetoUID = atribuicao.Projeto.UID
            };

            await atribuicaoService.EditarAsync(envio.AtribuicaoUID, atribuicaoEnvio, claims);

            //gera notificação
            var requisicao = await requisicaoService.ObterPorUIDAsync(atribuicao.Objeto.UID);

            var notificacao = new NotificacaoEnvioDTO()
            {
                Nome = $"Requisição {requisicao.Nome} completada.",
                Descricao = $"O Coordenador {requisicao.Coordenador.Nome} completou a requisição {requisicao.Nome}.",
                UsuarioUID = requisicao.UsuarioCriador.UID,
                Vista = false
            };

            await notificacaoService.AdicionarAsync(notificacao, claims);
        }
    }
}
