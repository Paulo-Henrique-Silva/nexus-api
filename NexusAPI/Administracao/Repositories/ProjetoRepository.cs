﻿using NexusAPI.Administracao.Models;
using NexusAPI.Compartilhado.Data;
using NexusAPI.Compartilhado.EntidadesBase.MVC;

namespace NexusAPI.Administracao.Repositories
{
    public class ProjetoRepository : NexusRepository<Projeto>
    {
        public ProjetoRepository(DataContext dataContext) : base(dataContext)
        {

        }
    }
}
