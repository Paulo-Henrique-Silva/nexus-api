using NexusAPI.Compartilhado;
using NexusAPI.Dados.Models;

namespace NexusAPI.Dados.Repositories
{
    public class EquipamentoRepository : BaseRepository<Equipamento>
    {
        public EquipamentoRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
