using NexusAPI.Compartilhado.EntidadesBase;
using System.ComponentModel.DataAnnotations.Schema;

namespace NexusAPI.Dados.Models
{
    [Table("LOCALIZACOES")]
    public class Localizacao : NexusObjeto
    {
        public Localizacao() : base() { }
    }
}
