﻿using NexusAPI.CicloVida.Enums;
using NexusAPI.Compartilhado.EntidadesBase;

namespace NexusAPI.CicloVida.DTOs.CicloVidaPasso
{
    public class CicloVidaPassoRespostaDTO : NexusRespostaDTO
    {
        public NexusNomeObjeto CicloVida { get; set; } = new NexusNomeObjeto();

        public NexusNomeObjeto PassoFalha { get; set; } = new NexusNomeObjeto();

        public NexusNomeObjeto PassoSucesso { get; set; } = new NexusNomeObjeto();

        public TipoCicloVidaPasso Tipo { get; set; }
    }
}
