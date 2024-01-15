﻿using NexusAPI.Administracao.Models;
using NexusAPI.CicloVidaAtivo.Enums;
using NexusAPI.CicloVidaAtivo.Models;
using NexusAPI.Compartilhado.EntidadesBase;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NexusAPI.CicloVidaAtivo.DTOs.Atribuicao
{
    public class AtribuicaoEnvioDTO : NexusEnvioDTO
    {
        public string UsuarioUID { get; set; } = "";

        public string CicloVidaPassoUID { get; set; } = "";

        public TipoAtribuicao Tipo { get; set; }
    }
}