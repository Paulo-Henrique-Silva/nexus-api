using NexusAPI.CicloVida.Models;
using NexusAPI.Compartilhado;
using NexusAPI.Dados.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NexusAPI.Administracao.Models
{
    [Table("USUARIOS")]
    public class Usuario : ObjetoNexus
    {
        [Column("NOMEACESSO")]
        [Required]
        public string NomeAcesso { get; set; }

        [Column("SENHA")]
        [Required]
        public string Senha { get; set; }

        //propriedades de navegação
        //public List<Notificacao>? Notificacoes {  get; set; }

        //public List<UsuarioProjetoPerfil>? UsuarioProjetoPerfil {  get; set; }

        //public List<Atribuicao>? Atribuicoes { get; set; }

        //public List<Manutencao>? Manutencoes { get; set; }

        //public List<Requisicao>? Requisicoes { get; set; }

        protected Usuario() : base() { }

        public Usuario
        (
            string nome,
            string nomeAcesso,
            string senha,
            string usuarioCriador
        ) : base(nome, usuarioCriador)
        {
            NomeAcesso = nomeAcesso;
            Senha = senha;
        }
    }
}
