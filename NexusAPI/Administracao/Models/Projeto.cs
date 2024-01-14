using NexusAPI.Compartilhado.EntidadesBase;
using System.ComponentModel.DataAnnotations.Schema;

namespace NexusAPI.Administracao.Models
{
    [Table("PROJETOS")]
    public class Projeto : NexusObjeto
    {
        public Projeto() : base() { }
    }
}
