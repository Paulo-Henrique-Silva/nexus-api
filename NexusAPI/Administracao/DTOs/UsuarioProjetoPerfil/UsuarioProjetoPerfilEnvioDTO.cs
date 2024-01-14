﻿using NexusAPI.Compartilhado.EntidadesBase;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NexusAPI.Administracao.DTOs.UsuarioProjetoPerfil
{
    public class UsuarioProjetoPerfilEnvioDTO : NexusEnvioDTO
    {
        public string UsuarioUID { get; set; } = "";

        public string ProjetoUID { get; set; } = "";

        public string PerfilUID { get; set; } = "";

        public bool Ativado { get; set; }
    }
}
