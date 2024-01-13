using NexusAPI.Compartilhado;
using System.ComponentModel.DataAnnotations.Schema;

namespace NexusAPI.Administracao.Models
{
    [Table("PERFIS")]
    public class Perfil : ObjetoNexus
    {
        protected Perfil() : base() { }

        public Perfil
        (
            string nome, 
            string usuarioCriador
        ) 
        : base(nome, usuarioCriador)
        {

        }
    }
}
