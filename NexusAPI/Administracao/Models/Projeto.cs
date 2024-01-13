using NexusAPI.Compartilhado;
using System.ComponentModel.DataAnnotations.Schema;

namespace NexusAPI.Administracao.Models
{
    [Table("PROJETOS")]
    public class Projeto : ObjetoNexus
    {
        protected Projeto() : base() { }

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
