using Microsoft.EntityFrameworkCore;
using NexusAPI.CicloVidaAtivo.Models;
using NexusAPI.Compartilhado.Data;
using NexusAPI.Compartilhado.EntidadesBase.MVC;
using NexusAPI.Compartilhado.Interfaces;

namespace NexusAPI.CicloVidaAtivo.Repositories
{
    public class CicloVidaRepository : NexusRepository<CicloVida>
    {
        public CicloVidaRepository(DataContext dataContext) : base(dataContext)
        {
        }

    }
}
