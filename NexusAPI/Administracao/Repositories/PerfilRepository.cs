﻿using NexusAPI.Administracao.Models;
using NexusAPI.Compartilhado.Data;
using NexusAPI.Compartilhado.EntidadesBase;

namespace NexusAPI.Administracao.Repositories
{
    public class PerfilRepository : NexusRepository<Perfil>
    {
        public PerfilRepository(DataContext dataContext) : base(dataContext)
        {
            
        }
    }
}
