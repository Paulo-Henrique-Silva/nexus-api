﻿using NexusAPI.Administracao.Models;
using NexusAPI.CicloVidaAtivo.Enums;
using NexusAPI.CicloVidaAtivo.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using NexusAPI.Compartilhado.EntidadesBase.DTOs;

namespace NexusAPI.CicloVidaAtivo.DTOs.Atribuicao
{
    public class AtribuicaoEnvioDTO : NexusEnvioDTO
    {
        public string UsuarioUID { get; set; } = "";

        public TipoAtribuicao Tipo { get; set; }

        public DateTime DataVencimento { get; set; }

        public bool Concluida { get; set; }

        public string ObjetoUID { get; set; } = "";

        public string ProjetoUID { get; set; } = "";
    }
}
