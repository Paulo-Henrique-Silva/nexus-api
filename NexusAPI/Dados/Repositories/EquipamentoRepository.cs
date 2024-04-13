using Microsoft.EntityFrameworkCore;
using NexusAPI.Compartilhado.Data;
using NexusAPI.Compartilhado.EntidadesBase.MVC;
using NexusAPI.Compartilhado.Interfaces;
using NexusAPI.Dados.Interfaces;
using NexusAPI.Dados.Models;

namespace NexusAPI.Dados.Repositories
{
    public class EquipamentoRepository : NexusRepository<Equipamento>, IProjetoItemRepository<Equipamento>, IPatrimonioRepository<Equipamento>
    {
        public EquipamentoRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public override async Task<Equipamento?> ObterPorUIDAsync(string UID)
        {
            return await dataContext.Set<Equipamento>()
                .Include(obj => obj.AtualizadoPor)
                .Include(obj => obj.UsuarioCriador)
                .Include(obj => obj.Projeto)
                .Include(obj => obj.Componente)
                .FirstOrDefaultAsync(obj => obj.UID.Equals(UID) && obj.DataFinalizacao == null);
        }

        public override async Task<List<Equipamento>> ObterTudoAsync(int? numeroPagina)
        {
            int pagina = numeroPagina.HasValue ? (int)numeroPagina : 1;

            return await dataContext.Set<Equipamento>()
                .Include(obj => obj.AtualizadoPor)
                .Include(obj => obj.UsuarioCriador)
                .Include(obj => obj.Projeto)
                .Include(obj => obj.Componente)
                .Where(obj => obj.DataFinalizacao == null)
                .OrderByDescending(obj => obj.DataCriacao)
                .Skip((pagina - 1) * Constantes.QUANTIDADE_ITEMS_PAGINA)
                .Take(Constantes.QUANTIDADE_ITEMS_PAGINA)
                .ToListAsync();
        }

        public override async Task<List<Equipamento>> ObterTudoPorNomeAsync(string nome, int? numeroPagina)
        {
            int pagina = numeroPagina.HasValue ? (int)numeroPagina : 1;

            return await dataContext.Set<Equipamento>()
                .Include(obj => obj.AtualizadoPor)
                .Include(obj => obj.UsuarioCriador)
                .Include(obj => obj.Projeto)
                .Include(obj => obj.Componente)
                .Where(obj => obj.DataFinalizacao == null && obj.Nome.Contains(nome))
                .OrderByDescending(obj => obj.DataCriacao)
                .Skip((pagina - 1) * Constantes.QUANTIDADE_ITEMS_PAGINA)
                .Take(Constantes.QUANTIDADE_ITEMS_PAGINA)
                .ToListAsync();
        }

        /// <summary>
        /// Obtém a quantidade itens não finalizados, pelo projeto especificado.
        /// </summary>
        /// <param name="numeroPagina"></param>
        /// <returns></returns>
        public virtual async Task<int> ObterCountPorProjetoUIDAsync(string projetoUID)
        {
            return await dataContext.Set<Equipamento>()
                .Where(obj => obj.DataFinalizacao == null && obj.ProjetoUID.Equals(projetoUID))
                .CountAsync();
        }

        public virtual async Task<int> ObterCountPorProjetoENomeAsync(string projetoUID, string nome)
        {
            return await dataContext.Set<Equipamento>()
                .Where(obj => obj.DataFinalizacao == null && obj.ProjetoUID.Equals(projetoUID) &&
                obj.Nome.Contains(nome))
                .CountAsync();
        }

        public async Task<List<Equipamento>> ObterTudoPorProjetoUIDAsync(int numeroPagina, string projetoUID)
        {
            return await dataContext.Set<Equipamento>()
                .Include(obj => obj.AtualizadoPor)
                .Include(obj => obj.UsuarioCriador)
                .Include(obj => obj.Projeto)
                .Include(obj => obj.Componente)
                .Where(obj => obj.DataFinalizacao == null && obj.ProjetoUID.Equals(projetoUID))
                .OrderByDescending(obj => obj.DataCriacao)
                .Skip((numeroPagina - 1) * Constantes.QUANTIDADE_ITEMS_PAGINA)
                .Take(Constantes.QUANTIDADE_ITEMS_PAGINA)
                .ToListAsync();
        }

        public async Task<List<Equipamento>> ObterTudoPorProjetoENomeAsync(int numeroPagina, string projetoUID, string nome)
        {
            return await dataContext.Set<Equipamento>()
                .Include(obj => obj.AtualizadoPor)
                .Include(obj => obj.UsuarioCriador)
                .Include(obj => obj.Projeto)
                .Include(obj => obj.Componente)
                .Where(obj => obj.DataFinalizacao == null && obj.ProjetoUID.Equals(projetoUID) &&
                obj.Nome.Contains(nome))
                .OrderByDescending(obj => obj.DataCriacao)
                .Skip((numeroPagina - 1) * Constantes.QUANTIDADE_ITEMS_PAGINA)
                .Take(Constantes.QUANTIDADE_ITEMS_PAGINA)
                .ToListAsync();
        }

        public async Task<Equipamento?> ObterPorNumeroSerieAsync(string numeroSerie)
        {
            //EF não suporta comparações com case sensitive, logo, é feita a lógica abaixo.
            var equipamento = await dataContext.Set<Equipamento>()
                .Where(obj => obj.NumeroSerie.Equals(numeroSerie) && obj.DataFinalizacao == null)
                .FirstOrDefaultAsync();

            return equipamento == null || !equipamento.NumeroSerie.Equals(numeroSerie, StringComparison.Ordinal) ? null : equipamento;
        }
    }
}
