using NexusAPI.Compartilhado.EntidadesBase;
using System.ComponentModel.DataAnnotations.Schema;

namespace NexusAPI.Dados.Models
{
    [Table("LOCALIZACOES")]
    public class Localizacao : BaseObjeto
    {
        protected Localizacao() : base() { }

        public Localizacao(string nome, string usuarioCriador) : base(nome, usuarioCriador)
        {
        }
    }
}
