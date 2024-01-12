using NexusAPI.Compartilhado;
using System.ComponentModel.DataAnnotations.Schema;

namespace NexusAPI.Administracao.Models
{
    [Table("PERFIL")]
    public class Perfil : ObjetoNexus
    {
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
