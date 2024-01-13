﻿using NexusAPI.Compartilhado.Data;
using NexusAPI.Compartilhado.EntidadesBase;
using NexusAPI.Dados.Models;

namespace NexusAPI.Dados.Repositories
{
    public class ManutencaoRepository : BaseRepository<Manutencao>
    {
        public ManutencaoRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}