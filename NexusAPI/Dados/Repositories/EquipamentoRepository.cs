using NexusAPI.Compartilhado.Data;
using NexusAPI.Compartilhado.EntidadesBase;
using NexusAPI.Dados.Models;

namespace NexusAPI.Dados.Repositories
{
    public class EquipamentoRepository : NexusRepository<Equipamento>
    {
        public EquipamentoRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
