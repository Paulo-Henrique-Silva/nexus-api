using NexusAPI.Compartilhado.EntidadesBase;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NexusAPI.Administracao.DTOs.UsuarioPerfil
{
    //Não herda a classe pois é um relacionamento e não uma entidade em si.
    public class UsuarioPerfilEnvioDTO
    {
        public string UsuarioUID { get; set; } = "";

        public string ProjetoUID { get; set; } = "";

        public string PerfilUID { get; set; } = "";

        public bool Ativado { get; set; }
    }
}
