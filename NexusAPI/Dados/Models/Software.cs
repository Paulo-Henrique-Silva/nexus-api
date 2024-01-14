﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using NexusAPI.Compartilhado.EntidadesBase;

namespace NexusAPI.Dados.Models
{
    [Table("SOFTWARES")]
    public class Software : NexusObjeto
    {
        [Column("LOCALIZACAOUID")]
        [ForeignKey("Localizacao")]
        [Required]
        public string LocalizacaoUID { get; set; } = "";

        public Localizacao? Localizacao { get; set; }

        [Column("COMPONENTEUID")]
        [ForeignKey("Componente")]
        [Required]
        public string ComponenteUID { get; set; } = "";

        public Componente? Componente { get; set; }

        [Column("CHAVELICENCA")]
        [Required]
        public string ChaveLicenca { get; set; } = "";

        [Column("DATAVENCIMENTO")]
        public DateTime? DataVencimento { get; set; }

        public Software() : base() { }
    }
}
