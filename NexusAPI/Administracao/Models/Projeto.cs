using NexusAPI.Compartilhado;
using System.ComponentModel.DataAnnotations.Schema;

namespace NexusAPI.Administracao.Models
{
    [Table("PROJETO")]
    public class Projeto : ObjetoNexus
    {
        public Projeto
        (
            string nome,
            string usuarioCriador
        )
        : base(nome, usuarioCriador)
        {

        }
    }
}
