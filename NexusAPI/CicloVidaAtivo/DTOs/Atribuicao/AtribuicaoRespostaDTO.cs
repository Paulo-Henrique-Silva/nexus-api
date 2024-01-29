﻿using NexusAPI.CicloVidaAtivo.Enums;
using NexusAPI.Compartilhado.EntidadesBase.DTOs;
using NexusAPI.Compartilhado.EntidadesBase.Objetos;

namespace NexusAPI.CicloVidaAtivo.DTOs.Atribuicao
{
    public class AtribuicaoRespostaDTO : NexusRespostaDTO
    {
        public NexusNomeObjeto Usuario { get; set; } = new NexusNomeObjeto();

        public TipoAtribuicao Tipo { get; set; }

        public DateTime DataVencimento { get; set; }

        public bool Concluida { get; set; }

        public NexusNomeObjeto CicloVida { get; set; } = new NexusNomeObjeto();
    }
}
