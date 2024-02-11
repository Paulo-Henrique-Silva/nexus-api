﻿using NexusAPI.Administracao.Models;
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
                Finalizado = false,
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
                "o campo de \"Solução\" para que a opção para marcar como concluída apareça.",
                UsuarioUID = tokenService.ObterUsuarioUID(claims),
                Tipo = TipoAtribuicao.Completar,
                DataVencimento = DateTime.Now.AddDays(3),
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
    }
}
