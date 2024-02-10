using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NexusAPI.Administracao.Models;
using NexusAPI.CicloVidaAtivo.Models;
using NexusAPI.Dados.Models;

namespace NexusAPI.Compartilhado.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Notificacao> Notificacoes { get; set; }

        public DbSet<Perfil> Perfis { get; set; }

        public DbSet<Projeto> Projetos { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<UsuarioPerfil> UsuarioProjetoPerfil { get; set; }

        public DbSet<Atribuicao> Atribuicoes { get; set; }

        public DbSet<CicloVida> CiclosVida { get; set; }

        public DbSet<Componente> Componentes { get; set; }

        public DbSet<Equipamento> Equipamentos { get; set; }

        public DbSet<Localizacao> Localizacoes { get; set; }

        public DbSet<Manutencao> Manutencoes { get; set; }

        public DbSet<Requisicao> Requisicoes { get; set; }

        public DbSet<Software> Softwares { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Localizacao>()
                .ToTable(tb => tb.HasTrigger("LocalizacoesDeletada"));

            modelBuilder
                .Entity<Componente>()
                .ToTable(tb => tb.HasTrigger("ComponentesDeletado"));

            modelBuilder
                .Entity<Componente>()
                .ToTable(tb => tb.HasTrigger("ProjetosDeletado"));

            modelBuilder
                .Entity<Componente>()
                .ToTable(tb => tb.HasTrigger("UsuariosDeletado"));
        }
    }
}
