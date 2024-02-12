using NexusAPI.Administracao.Models;
using NexusAPI.CicloVidaAtivo.DTOs.Atribuicao;
using NexusAPI.CicloVidaAtivo.DTOs.CicloVida;
using NexusAPI.CicloVidaAtivo.Enums;
using NexusAPI.CicloVidaAtivo.Models;
using NexusAPI.CicloVidaAtivo.Repositories;
using NexusAPI.Compartilhado.EntidadesBase.CicloVida;
using NexusAPI.Compartilhado.Services;
using NexusAPI.Dados.DTOs.Componente;
using NexusAPI.Dados.Enums;
using NexusAPI.Dados.Services;
using System.Security.Claims;

namespace NexusAPI.CicloVidaAtivo.Services
{
    /// <summary>
    /// Usuários podem criar manutenções. As manutenções podem ser atribuídas para 
    /// o próprio usuário ou para outro. O usuário atribuído deverá marcar a manuteção como concluída, depois que preencher
    /// o campo de solução.
    /// </summary>
    public class VerificacaoManutencaoService : NexusCicloVidaService
    {
        private readonly ManutencaoService manutencaoService;

        private readonly ComponenteService componenteService;

        public VerificacaoManutencaoService(AtribuicaoService atribuicaoService, 
            CicloVidaRepository cicloVidaRepository, ManutencaoService manutencaoService, 
            ComponenteService componenteService, TokenService tokenService) 
        : base(atribuicaoService, cicloVidaRepository, tokenService)
        {
            this.manutencaoService = manutencaoService;
            this.componenteService = componenteService;
        }

        public override async Task IniciarCiclovida(CicloVidaIniciarDTO envio, IEnumerable<Claim> claims)
        {
            //Cria um novo ciclo de vida de verificação e vai para o primeiro passo.
            CicloVida cicloVida = new()
            {
                UID = Guid.NewGuid().ToString(),
                Nome = "Verificação de Manutenção",
                Descricao = "Verificação de manutenção pelo responsável.",
                ObjetoUID = envio.ObjetoUID,
                Concluido = false,
                UsuarioCriadorUID = tokenService.ObterUsuarioUID(claims),
            };

            await cicloVidaRepository.AdicionarAsync(cicloVida);
            await CriacaoManutencao(cicloVida.UID, envio.ObjetoUID, claims);
        }

        public async Task CriacaoManutencao(string cicloVidaUID, string manutencaoUID,
            IEnumerable<Claim> claims)
        {
            //Cria uma nova atribuição para o usuário.
            var atribuicao = new AtribuicaoEnvioDTO()
            {
                Nome = "Completar Manutenção",
                Descricao = "Verifique os detalhes da manutenção. Após concluí-la, por favor, atualize " +
                "o campo de \"Solução\" para que a opção de marcar como concluída apareça.",
                UsuarioUID = tokenService.ObterUsuarioUID(claims),
                Tipo = TipoAtribuicao.CompletarManutencao,
                DataVencimento = ObterDataDiasUteis(3),
                Concluida = false,
                CicloVidaUID = cicloVidaUID,
            };

            await atribuicaoService.AdicionarAsync(atribuicao, claims);

            //Muda status do componente para "Em manutenção".
            var manutencao = await manutencaoService.ObterPorUIDAsync(manutencaoUID);
            var componente = await componenteService.ObterPorUIDAsync(manutencao.Componente.UID);

            var componenteAttManutencao = new ComponenteEnvioDTO()
            {
                Nome = componente.Nome,
                Descricao = componente.Descricao ?? "",
                NumeroSerie = componente.NumeroSerie,
                LocalizacaoUID  = componente.Localizacao.UID,
                ProjetoUID  = componente.Projeto.UID,
                Status = StatusComponente.EmManutencao, //Muda para Em Manutenção.
                Marca  = componente.Marca,
                Modelo  = componente.Modelo,
                Tipo = (TipoComponente)Enum.Parse(typeof(TipoComponente), componente.Tipo.UID),
                DataAquisicao = componente.DataAquisicao,
            };

            await componenteService.EditarAsync(componente.UID, componenteAttManutencao, claims);
        }

        public async Task UsuarioConcluiu()
        {

        }

        private static DateTime ObterDataDiasUteis(int quantidadeDiasUteis)
        {
            int diasUteis = 0;
            DateTime data = DateTime.Now;

            while (diasUteis < quantidadeDiasUteis)
            {
                data = data.AddDays(1);

                if (data.DayOfWeek != DayOfWeek.Saturday && data.DayOfWeek != DayOfWeek.Sunday)
                {
                    diasUteis++;
                }
            }

            //Muda o horário para 17:59, fim do horário comercial.
            return new DateTime(data.Year, data.Month, data.Day, 17, 59, 0);
        }
    }
}
