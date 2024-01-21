using NexusAPI.Administracao.Models;
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

        public TipoAtribuicao Tipo { get; set; }

        public DateTime DataVencimento { get; set; }

        public bool Concluida { get; set; }

        public string CicloVidaUID { get; set; } = "";
    }
}
