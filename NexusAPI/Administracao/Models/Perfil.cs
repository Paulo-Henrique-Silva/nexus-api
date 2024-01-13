using NexusAPI.Compartilhado.EntidadesBase;
using System.ComponentModel.DataAnnotations.Schema;

namespace NexusAPI.Administracao.Models
{
    [Table("PERFIS")]
    public class Perfil : BaseObjeto
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
