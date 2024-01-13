using NexusAPI.Compartilhado.EntidadesBase;
using System.ComponentModel.DataAnnotations.Schema;

namespace NexusAPI.Administracao.Models
{
    [Table("PROJETOS")]
    public class Projeto : BaseObjeto
    {
        public Projeto() : base() { }
    }
}
