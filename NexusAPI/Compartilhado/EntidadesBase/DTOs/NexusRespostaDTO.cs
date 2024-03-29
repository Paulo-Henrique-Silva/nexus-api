﻿using NexusAPI.Compartilhado.EntidadesBase.Objetos;

namespace NexusAPI.Compartilhado.EntidadesBase.DTOs
{
    public abstract class NexusRespostaDTO
    {
        public string UID { get; set; } = "";

        public string Nome { get; set; } = "";

        public string? Descricao { get; set; }

        public DateTime? DataUltimaAtualizacao { get; set; }

        public NexusReferenciaObjeto? AtualizadoPor { get; set; }

        public NexusReferenciaObjeto? UsuarioCriador { get; set; }

        public DateTime DataCriacao { get; set; }
    }
}
