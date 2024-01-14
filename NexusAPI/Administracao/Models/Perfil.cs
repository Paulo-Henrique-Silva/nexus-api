using NexusAPI.Compartilhado.EntidadesBase;
using System.ComponentModel.DataAnnotations.Schema;

namespace NexusAPI.Administracao.Models
{
    [Table("PERFIS")]
    public class Perfil : NexusObjeto
    {
        public Perfil() : base() { }
    }
}
