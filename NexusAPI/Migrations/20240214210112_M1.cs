using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NexusAPI.Migrations
{
    /// <inheritdoc />
    public partial class M1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "USUARIOS",
                columns: table => new
                {
                    UID = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    NOMEACESSO = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    SENHA = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    NOME = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DESCRICAO = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    ATUALIZADOPORUID = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DATAULTIMAATUALIZACAO = table.Column<DateTime>(type: "datetime2", nullable: true),
                    USUARIOCRIADORUID = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DATACRIACAO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FINALIZADOPORUID = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DATAFINALIZACAO = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIOS", x => x.UID);
                    table.ForeignKey(
                        name: "FK_USUARIOS_USUARIOS_ATUALIZADOPORUID",
                        column: x => x.ATUALIZADOPORUID,
                        principalTable: "USUARIOS",
                        principalColumn: "UID");
                    table.ForeignKey(
                        name: "FK_USUARIOS_USUARIOS_FINALIZADOPORUID",
                        column: x => x.FINALIZADOPORUID,
                        principalTable: "USUARIOS",
                        principalColumn: "UID");
                    table.ForeignKey(
                        name: "FK_USUARIOS_USUARIOS_USUARIOCRIADORUID",
                        column: x => x.USUARIOCRIADORUID,
                        principalTable: "USUARIOS",
                        principalColumn: "UID");
                });

            migrationBuilder.CreateTable(
                name: "NOTIFICACOES",
                columns: table => new
                {
                    UID = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    USUARIOUID = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    VISTA = table.Column<bool>(type: "bit", nullable: false),
                    NOME = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DESCRICAO = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    ATUALIZADOPORUID = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DATAULTIMAATUALIZACAO = table.Column<DateTime>(type: "datetime2", nullable: true),
                    USUARIOCRIADORUID = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DATACRIACAO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FINALIZADOPORUID = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DATAFINALIZACAO = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NOTIFICACOES", x => x.UID);
                    table.ForeignKey(
                        name: "FK_NOTIFICACOES_USUARIOS_ATUALIZADOPORUID",
                        column: x => x.ATUALIZADOPORUID,
                        principalTable: "USUARIOS",
                        principalColumn: "UID");
                    table.ForeignKey(
                        name: "FK_NOTIFICACOES_USUARIOS_FINALIZADOPORUID",
                        column: x => x.FINALIZADOPORUID,
                        principalTable: "USUARIOS",
                        principalColumn: "UID");
                    table.ForeignKey(
                        name: "FK_NOTIFICACOES_USUARIOS_USUARIOCRIADORUID",
                        column: x => x.USUARIOCRIADORUID,
                        principalTable: "USUARIOS",
                        principalColumn: "UID");
                    table.ForeignKey(
                        name: "FK_NOTIFICACOES_USUARIOS_USUARIOUID",
                        column: x => x.USUARIOUID,
                        principalTable: "USUARIOS",
                        principalColumn: "UID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "PERFIS",
                columns: table => new
                {
                    UID = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    NOME = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DESCRICAO = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    ATUALIZADOPORUID = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DATAULTIMAATUALIZACAO = table.Column<DateTime>(type: "datetime2", nullable: true),
                    USUARIOCRIADORUID = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DATACRIACAO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FINALIZADOPORUID = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DATAFINALIZACAO = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PERFIS", x => x.UID);
                    table.ForeignKey(
                        name: "FK_PERFIS_USUARIOS_ATUALIZADOPORUID",
                        column: x => x.ATUALIZADOPORUID,
                        principalTable: "USUARIOS",
                        principalColumn: "UID");
                    table.ForeignKey(
                        name: "FK_PERFIS_USUARIOS_FINALIZADOPORUID",
                        column: x => x.FINALIZADOPORUID,
                        principalTable: "USUARIOS",
                        principalColumn: "UID");
                    table.ForeignKey(
                        name: "FK_PERFIS_USUARIOS_USUARIOCRIADORUID",
                        column: x => x.USUARIOCRIADORUID,
                        principalTable: "USUARIOS",
                        principalColumn: "UID");
                });

            migrationBuilder.CreateTable(
                name: "PROJETOS",
                columns: table => new
                {
                    UID = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    NOME = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DESCRICAO = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    ATUALIZADOPORUID = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DATAULTIMAATUALIZACAO = table.Column<DateTime>(type: "datetime2", nullable: true),
                    USUARIOCRIADORUID = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DATACRIACAO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FINALIZADOPORUID = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DATAFINALIZACAO = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PROJETOS", x => x.UID);
                    table.ForeignKey(
                        name: "FK_PROJETOS_USUARIOS_ATUALIZADOPORUID",
                        column: x => x.ATUALIZADOPORUID,
                        principalTable: "USUARIOS",
                        principalColumn: "UID");
                    table.ForeignKey(
                        name: "FK_PROJETOS_USUARIOS_FINALIZADOPORUID",
                        column: x => x.FINALIZADOPORUID,
                        principalTable: "USUARIOS",
                        principalColumn: "UID");
                    table.ForeignKey(
                        name: "FK_PROJETOS_USUARIOS_USUARIOCRIADORUID",
                        column: x => x.USUARIOCRIADORUID,
                        principalTable: "USUARIOS",
                        principalColumn: "UID");
                });

            migrationBuilder.CreateTable(
                name: "ATRIBUICOES",
                columns: table => new
                {
                    UID = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    USUARIOUID = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    TIPO = table.Column<int>(type: "int", nullable: false),
                    OBJETOUID = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PROJETOUID = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DATAVENCIMENTO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CONCLUIDA = table.Column<bool>(type: "bit", nullable: false),
                    NOME = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DESCRICAO = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    ATUALIZADOPORUID = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DATAULTIMAATUALIZACAO = table.Column<DateTime>(type: "datetime2", nullable: true),
                    USUARIOCRIADORUID = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DATACRIACAO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FINALIZADOPORUID = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DATAFINALIZACAO = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ATRIBUICOES", x => x.UID);
                    table.ForeignKey(
                        name: "FK_ATRIBUICOES_PROJETOS_PROJETOUID",
                        column: x => x.PROJETOUID,
                        principalTable: "PROJETOS",
                        principalColumn: "UID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ATRIBUICOES_USUARIOS_ATUALIZADOPORUID",
                        column: x => x.ATUALIZADOPORUID,
                        principalTable: "USUARIOS",
                        principalColumn: "UID");
                    table.ForeignKey(
                        name: "FK_ATRIBUICOES_USUARIOS_FINALIZADOPORUID",
                        column: x => x.FINALIZADOPORUID,
                        principalTable: "USUARIOS",
                        principalColumn: "UID");
                    table.ForeignKey(
                        name: "FK_ATRIBUICOES_USUARIOS_USUARIOCRIADORUID",
                        column: x => x.USUARIOCRIADORUID,
                        principalTable: "USUARIOS",
                        principalColumn: "UID");
                    table.ForeignKey(
                        name: "FK_ATRIBUICOES_USUARIOS_USUARIOUID",
                        column: x => x.USUARIOUID,
                        principalTable: "USUARIOS",
                        principalColumn: "UID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "LOCALIZACOES",
                columns: table => new
                {
                    UID = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PROJETOUID = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    NOME = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DESCRICAO = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    ATUALIZADOPORUID = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DATAULTIMAATUALIZACAO = table.Column<DateTime>(type: "datetime2", nullable: true),
                    USUARIOCRIADORUID = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DATACRIACAO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FINALIZADOPORUID = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DATAFINALIZACAO = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LOCALIZACOES", x => x.UID);
                    table.ForeignKey(
                        name: "FK_LOCALIZACOES_PROJETOS_PROJETOUID",
                        column: x => x.PROJETOUID,
                        principalTable: "PROJETOS",
                        principalColumn: "UID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_LOCALIZACOES_USUARIOS_ATUALIZADOPORUID",
                        column: x => x.ATUALIZADOPORUID,
                        principalTable: "USUARIOS",
                        principalColumn: "UID");
                    table.ForeignKey(
                        name: "FK_LOCALIZACOES_USUARIOS_FINALIZADOPORUID",
                        column: x => x.FINALIZADOPORUID,
                        principalTable: "USUARIOS",
                        principalColumn: "UID");
                    table.ForeignKey(
                        name: "FK_LOCALIZACOES_USUARIOS_USUARIOCRIADORUID",
                        column: x => x.USUARIOCRIADORUID,
                        principalTable: "USUARIOS",
                        principalColumn: "UID");
                });

            migrationBuilder.CreateTable(
                name: "REQUISICOES",
                columns: table => new
                {
                    UID = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    COORDENADORUID = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PROJETOUID = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    NOME = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DESCRICAO = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    ATUALIZADOPORUID = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DATAULTIMAATUALIZACAO = table.Column<DateTime>(type: "datetime2", nullable: true),
                    USUARIOCRIADORUID = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DATACRIACAO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FINALIZADOPORUID = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DATAFINALIZACAO = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_REQUISICOES", x => x.UID);
                    table.ForeignKey(
                        name: "FK_REQUISICOES_PROJETOS_PROJETOUID",
                        column: x => x.PROJETOUID,
                        principalTable: "PROJETOS",
                        principalColumn: "UID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_REQUISICOES_USUARIOS_ATUALIZADOPORUID",
                        column: x => x.ATUALIZADOPORUID,
                        principalTable: "USUARIOS",
                        principalColumn: "UID");
                    table.ForeignKey(
                        name: "FK_REQUISICOES_USUARIOS_COORDENADORUID",
                        column: x => x.COORDENADORUID,
                        principalTable: "USUARIOS",
                        principalColumn: "UID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_REQUISICOES_USUARIOS_FINALIZADOPORUID",
                        column: x => x.FINALIZADOPORUID,
                        principalTable: "USUARIOS",
                        principalColumn: "UID");
                    table.ForeignKey(
                        name: "FK_REQUISICOES_USUARIOS_USUARIOCRIADORUID",
                        column: x => x.USUARIOCRIADORUID,
                        principalTable: "USUARIOS",
                        principalColumn: "UID");
                });

            migrationBuilder.CreateTable(
                name: "USUARIOPERFIL",
                columns: table => new
                {
                    UID = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    USUARIOUID = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PROJETOUID = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PERFILUID = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ATIVADO = table.Column<bool>(type: "bit", nullable: false),
                    ATUALIZADOPORUID = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    DATAULTIMAATUALIZACAO = table.Column<DateTime>(type: "datetime2", nullable: true),
                    USUARIOCRIADORUID = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    DATACRIACAO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FINALIZADOPORUID = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    DATAFINALIZACAO = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIOPERFIL", x => x.UID);
                    table.ForeignKey(
                        name: "FK_USUARIOPERFIL_PERFIS_PERFILUID",
                        column: x => x.PERFILUID,
                        principalTable: "PERFIS",
                        principalColumn: "UID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_USUARIOPERFIL_PROJETOS_PROJETOUID",
                        column: x => x.PROJETOUID,
                        principalTable: "PROJETOS",
                        principalColumn: "UID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_USUARIOPERFIL_USUARIOS_ATUALIZADOPORUID",
                        column: x => x.ATUALIZADOPORUID,
                        principalTable: "USUARIOS",
                        principalColumn: "UID");
                    table.ForeignKey(
                        name: "FK_USUARIOPERFIL_USUARIOS_FINALIZADOPORUID",
                        column: x => x.FINALIZADOPORUID,
                        principalTable: "USUARIOS",
                        principalColumn: "UID");
                    table.ForeignKey(
                        name: "FK_USUARIOPERFIL_USUARIOS_USUARIOCRIADORUID",
                        column: x => x.USUARIOCRIADORUID,
                        principalTable: "USUARIOS",
                        principalColumn: "UID");
                    table.ForeignKey(
                        name: "FK_USUARIOPERFIL_USUARIOS_USUARIOUID",
                        column: x => x.USUARIOUID,
                        principalTable: "USUARIOS",
                        principalColumn: "UID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "COMPONENTES",
                columns: table => new
                {
                    UID = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    NUMEROSERIE = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    LOCALIZACAOUID = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    STATUS = table.Column<int>(type: "int", nullable: false),
                    MARCA = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    MODELO = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PROJETOUID = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    TIPO = table.Column<int>(type: "int", nullable: false),
                    DATAAQUISICAO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NOME = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DESCRICAO = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    ATUALIZADOPORUID = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DATAULTIMAATUALIZACAO = table.Column<DateTime>(type: "datetime2", nullable: true),
                    USUARIOCRIADORUID = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DATACRIACAO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FINALIZADOPORUID = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DATAFINALIZACAO = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COMPONENTES", x => x.UID);
                    table.ForeignKey(
                        name: "FK_COMPONENTES_LOCALIZACOES_LOCALIZACAOUID",
                        column: x => x.LOCALIZACAOUID,
                        principalTable: "LOCALIZACOES",
                        principalColumn: "UID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_COMPONENTES_PROJETOS_PROJETOUID",
                        column: x => x.PROJETOUID,
                        principalTable: "PROJETOS",
                        principalColumn: "UID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_COMPONENTES_USUARIOS_ATUALIZADOPORUID",
                        column: x => x.ATUALIZADOPORUID,
                        principalTable: "USUARIOS",
                        principalColumn: "UID");
                    table.ForeignKey(
                        name: "FK_COMPONENTES_USUARIOS_FINALIZADOPORUID",
                        column: x => x.FINALIZADOPORUID,
                        principalTable: "USUARIOS",
                        principalColumn: "UID");
                    table.ForeignKey(
                        name: "FK_COMPONENTES_USUARIOS_USUARIOCRIADORUID",
                        column: x => x.USUARIOCRIADORUID,
                        principalTable: "USUARIOS",
                        principalColumn: "UID");
                });

            migrationBuilder.CreateTable(
                name: "EQUIPAMENTOS",
                columns: table => new
                {
                    UID = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    NUMEROSERIE = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    LOCALIZACAOUID = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    COMPONENTEUID = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PROJETOUID = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    MARCA = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    MODELO = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    TIPO = table.Column<int>(type: "int", nullable: false),
                    DATAAQUISICAO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NOME = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DESCRICAO = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    ATUALIZADOPORUID = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DATAULTIMAATUALIZACAO = table.Column<DateTime>(type: "datetime2", nullable: true),
                    USUARIOCRIADORUID = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DATACRIACAO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FINALIZADOPORUID = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DATAFINALIZACAO = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EQUIPAMENTOS", x => x.UID);
                    table.ForeignKey(
                        name: "FK_EQUIPAMENTOS_COMPONENTES_COMPONENTEUID",
                        column: x => x.COMPONENTEUID,
                        principalTable: "COMPONENTES",
                        principalColumn: "UID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_EQUIPAMENTOS_LOCALIZACOES_LOCALIZACAOUID",
                        column: x => x.LOCALIZACAOUID,
                        principalTable: "LOCALIZACOES",
                        principalColumn: "UID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_EQUIPAMENTOS_PROJETOS_PROJETOUID",
                        column: x => x.PROJETOUID,
                        principalTable: "PROJETOS",
                        principalColumn: "UID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_EQUIPAMENTOS_USUARIOS_ATUALIZADOPORUID",
                        column: x => x.ATUALIZADOPORUID,
                        principalTable: "USUARIOS",
                        principalColumn: "UID");
                    table.ForeignKey(
                        name: "FK_EQUIPAMENTOS_USUARIOS_FINALIZADOPORUID",
                        column: x => x.FINALIZADOPORUID,
                        principalTable: "USUARIOS",
                        principalColumn: "UID");
                    table.ForeignKey(
                        name: "FK_EQUIPAMENTOS_USUARIOS_USUARIOCRIADORUID",
                        column: x => x.USUARIOCRIADORUID,
                        principalTable: "USUARIOS",
                        principalColumn: "UID");
                });

            migrationBuilder.CreateTable(
                name: "MANUTENCOES",
                columns: table => new
                {
                    UID = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    COMPONENTEUID = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PROJETOUID = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DATAINICIO = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DATATERMINO = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RESPONSAVELUID = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    SOLUCAO = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    NOME = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DESCRICAO = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    ATUALIZADOPORUID = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DATAULTIMAATUALIZACAO = table.Column<DateTime>(type: "datetime2", nullable: true),
                    USUARIOCRIADORUID = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DATACRIACAO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FINALIZADOPORUID = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DATAFINALIZACAO = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MANUTENCOES", x => x.UID);
                    table.ForeignKey(
                        name: "FK_MANUTENCOES_COMPONENTES_COMPONENTEUID",
                        column: x => x.COMPONENTEUID,
                        principalTable: "COMPONENTES",
                        principalColumn: "UID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_MANUTENCOES_PROJETOS_PROJETOUID",
                        column: x => x.PROJETOUID,
                        principalTable: "PROJETOS",
                        principalColumn: "UID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_MANUTENCOES_USUARIOS_ATUALIZADOPORUID",
                        column: x => x.ATUALIZADOPORUID,
                        principalTable: "USUARIOS",
                        principalColumn: "UID");
                    table.ForeignKey(
                        name: "FK_MANUTENCOES_USUARIOS_FINALIZADOPORUID",
                        column: x => x.FINALIZADOPORUID,
                        principalTable: "USUARIOS",
                        principalColumn: "UID");
                    table.ForeignKey(
                        name: "FK_MANUTENCOES_USUARIOS_RESPONSAVELUID",
                        column: x => x.RESPONSAVELUID,
                        principalTable: "USUARIOS",
                        principalColumn: "UID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_MANUTENCOES_USUARIOS_USUARIOCRIADORUID",
                        column: x => x.USUARIOCRIADORUID,
                        principalTable: "USUARIOS",
                        principalColumn: "UID");
                });

            migrationBuilder.CreateTable(
                name: "SOFTWARES",
                columns: table => new
                {
                    UID = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    COMPONENTEUID = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PROJETOUID = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CHAVELICENCA = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DATAVENCIMENTO = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NOME = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DESCRICAO = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    ATUALIZADOPORUID = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DATAULTIMAATUALIZACAO = table.Column<DateTime>(type: "datetime2", nullable: true),
                    USUARIOCRIADORUID = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DATACRIACAO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FINALIZADOPORUID = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DATAFINALIZACAO = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SOFTWARES", x => x.UID);
                    table.ForeignKey(
                        name: "FK_SOFTWARES_COMPONENTES_COMPONENTEUID",
                        column: x => x.COMPONENTEUID,
                        principalTable: "COMPONENTES",
                        principalColumn: "UID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_SOFTWARES_PROJETOS_PROJETOUID",
                        column: x => x.PROJETOUID,
                        principalTable: "PROJETOS",
                        principalColumn: "UID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_SOFTWARES_USUARIOS_ATUALIZADOPORUID",
                        column: x => x.ATUALIZADOPORUID,
                        principalTable: "USUARIOS",
                        principalColumn: "UID");
                    table.ForeignKey(
                        name: "FK_SOFTWARES_USUARIOS_FINALIZADOPORUID",
                        column: x => x.FINALIZADOPORUID,
                        principalTable: "USUARIOS",
                        principalColumn: "UID");
                    table.ForeignKey(
                        name: "FK_SOFTWARES_USUARIOS_USUARIOCRIADORUID",
                        column: x => x.USUARIOCRIADORUID,
                        principalTable: "USUARIOS",
                        principalColumn: "UID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ATRIBUICOES_ATUALIZADOPORUID",
                table: "ATRIBUICOES",
                column: "ATUALIZADOPORUID");

            migrationBuilder.CreateIndex(
                name: "IX_ATRIBUICOES_FINALIZADOPORUID",
                table: "ATRIBUICOES",
                column: "FINALIZADOPORUID");

            migrationBuilder.CreateIndex(
                name: "IX_ATRIBUICOES_PROJETOUID",
                table: "ATRIBUICOES",
                column: "PROJETOUID");

            migrationBuilder.CreateIndex(
                name: "IX_ATRIBUICOES_USUARIOCRIADORUID",
                table: "ATRIBUICOES",
                column: "USUARIOCRIADORUID");

            migrationBuilder.CreateIndex(
                name: "IX_ATRIBUICOES_USUARIOUID",
                table: "ATRIBUICOES",
                column: "USUARIOUID");

            migrationBuilder.CreateIndex(
                name: "IX_COMPONENTES_ATUALIZADOPORUID",
                table: "COMPONENTES",
                column: "ATUALIZADOPORUID");

            migrationBuilder.CreateIndex(
                name: "IX_COMPONENTES_FINALIZADOPORUID",
                table: "COMPONENTES",
                column: "FINALIZADOPORUID");

            migrationBuilder.CreateIndex(
                name: "IX_COMPONENTES_LOCALIZACAOUID",
                table: "COMPONENTES",
                column: "LOCALIZACAOUID");

            migrationBuilder.CreateIndex(
                name: "IX_COMPONENTES_PROJETOUID",
                table: "COMPONENTES",
                column: "PROJETOUID");

            migrationBuilder.CreateIndex(
                name: "IX_COMPONENTES_USUARIOCRIADORUID",
                table: "COMPONENTES",
                column: "USUARIOCRIADORUID");

            migrationBuilder.CreateIndex(
                name: "IX_EQUIPAMENTOS_ATUALIZADOPORUID",
                table: "EQUIPAMENTOS",
                column: "ATUALIZADOPORUID");

            migrationBuilder.CreateIndex(
                name: "IX_EQUIPAMENTOS_COMPONENTEUID",
                table: "EQUIPAMENTOS",
                column: "COMPONENTEUID");

            migrationBuilder.CreateIndex(
                name: "IX_EQUIPAMENTOS_FINALIZADOPORUID",
                table: "EQUIPAMENTOS",
                column: "FINALIZADOPORUID");

            migrationBuilder.CreateIndex(
                name: "IX_EQUIPAMENTOS_LOCALIZACAOUID",
                table: "EQUIPAMENTOS",
                column: "LOCALIZACAOUID");

            migrationBuilder.CreateIndex(
                name: "IX_EQUIPAMENTOS_PROJETOUID",
                table: "EQUIPAMENTOS",
                column: "PROJETOUID");

            migrationBuilder.CreateIndex(
                name: "IX_EQUIPAMENTOS_USUARIOCRIADORUID",
                table: "EQUIPAMENTOS",
                column: "USUARIOCRIADORUID");

            migrationBuilder.CreateIndex(
                name: "IX_LOCALIZACOES_ATUALIZADOPORUID",
                table: "LOCALIZACOES",
                column: "ATUALIZADOPORUID");

            migrationBuilder.CreateIndex(
                name: "IX_LOCALIZACOES_FINALIZADOPORUID",
                table: "LOCALIZACOES",
                column: "FINALIZADOPORUID");

            migrationBuilder.CreateIndex(
                name: "IX_LOCALIZACOES_PROJETOUID",
                table: "LOCALIZACOES",
                column: "PROJETOUID");

            migrationBuilder.CreateIndex(
                name: "IX_LOCALIZACOES_USUARIOCRIADORUID",
                table: "LOCALIZACOES",
                column: "USUARIOCRIADORUID");

            migrationBuilder.CreateIndex(
                name: "IX_MANUTENCOES_ATUALIZADOPORUID",
                table: "MANUTENCOES",
                column: "ATUALIZADOPORUID");

            migrationBuilder.CreateIndex(
                name: "IX_MANUTENCOES_COMPONENTEUID",
                table: "MANUTENCOES",
                column: "COMPONENTEUID");

            migrationBuilder.CreateIndex(
                name: "IX_MANUTENCOES_FINALIZADOPORUID",
                table: "MANUTENCOES",
                column: "FINALIZADOPORUID");

            migrationBuilder.CreateIndex(
                name: "IX_MANUTENCOES_PROJETOUID",
                table: "MANUTENCOES",
                column: "PROJETOUID");

            migrationBuilder.CreateIndex(
                name: "IX_MANUTENCOES_RESPONSAVELUID",
                table: "MANUTENCOES",
                column: "RESPONSAVELUID");

            migrationBuilder.CreateIndex(
                name: "IX_MANUTENCOES_USUARIOCRIADORUID",
                table: "MANUTENCOES",
                column: "USUARIOCRIADORUID");

            migrationBuilder.CreateIndex(
                name: "IX_NOTIFICACOES_ATUALIZADOPORUID",
                table: "NOTIFICACOES",
                column: "ATUALIZADOPORUID");

            migrationBuilder.CreateIndex(
                name: "IX_NOTIFICACOES_FINALIZADOPORUID",
                table: "NOTIFICACOES",
                column: "FINALIZADOPORUID");

            migrationBuilder.CreateIndex(
                name: "IX_NOTIFICACOES_USUARIOCRIADORUID",
                table: "NOTIFICACOES",
                column: "USUARIOCRIADORUID");

            migrationBuilder.CreateIndex(
                name: "IX_NOTIFICACOES_USUARIOUID",
                table: "NOTIFICACOES",
                column: "USUARIOUID");

            migrationBuilder.CreateIndex(
                name: "IX_PERFIS_ATUALIZADOPORUID",
                table: "PERFIS",
                column: "ATUALIZADOPORUID");

            migrationBuilder.CreateIndex(
                name: "IX_PERFIS_FINALIZADOPORUID",
                table: "PERFIS",
                column: "FINALIZADOPORUID");

            migrationBuilder.CreateIndex(
                name: "IX_PERFIS_USUARIOCRIADORUID",
                table: "PERFIS",
                column: "USUARIOCRIADORUID");

            migrationBuilder.CreateIndex(
                name: "IX_PROJETOS_ATUALIZADOPORUID",
                table: "PROJETOS",
                column: "ATUALIZADOPORUID");

            migrationBuilder.CreateIndex(
                name: "IX_PROJETOS_FINALIZADOPORUID",
                table: "PROJETOS",
                column: "FINALIZADOPORUID");

            migrationBuilder.CreateIndex(
                name: "IX_PROJETOS_USUARIOCRIADORUID",
                table: "PROJETOS",
                column: "USUARIOCRIADORUID");

            migrationBuilder.CreateIndex(
                name: "IX_REQUISICOES_ATUALIZADOPORUID",
                table: "REQUISICOES",
                column: "ATUALIZADOPORUID");

            migrationBuilder.CreateIndex(
                name: "IX_REQUISICOES_COORDENADORUID",
                table: "REQUISICOES",
                column: "COORDENADORUID");

            migrationBuilder.CreateIndex(
                name: "IX_REQUISICOES_FINALIZADOPORUID",
                table: "REQUISICOES",
                column: "FINALIZADOPORUID");

            migrationBuilder.CreateIndex(
                name: "IX_REQUISICOES_PROJETOUID",
                table: "REQUISICOES",
                column: "PROJETOUID");

            migrationBuilder.CreateIndex(
                name: "IX_REQUISICOES_USUARIOCRIADORUID",
                table: "REQUISICOES",
                column: "USUARIOCRIADORUID");

            migrationBuilder.CreateIndex(
                name: "IX_SOFTWARES_ATUALIZADOPORUID",
                table: "SOFTWARES",
                column: "ATUALIZADOPORUID");

            migrationBuilder.CreateIndex(
                name: "IX_SOFTWARES_COMPONENTEUID",
                table: "SOFTWARES",
                column: "COMPONENTEUID");

            migrationBuilder.CreateIndex(
                name: "IX_SOFTWARES_FINALIZADOPORUID",
                table: "SOFTWARES",
                column: "FINALIZADOPORUID");

            migrationBuilder.CreateIndex(
                name: "IX_SOFTWARES_PROJETOUID",
                table: "SOFTWARES",
                column: "PROJETOUID");

            migrationBuilder.CreateIndex(
                name: "IX_SOFTWARES_USUARIOCRIADORUID",
                table: "SOFTWARES",
                column: "USUARIOCRIADORUID");

            migrationBuilder.CreateIndex(
                name: "IX_USUARIOPERFIL_ATUALIZADOPORUID",
                table: "USUARIOPERFIL",
                column: "ATUALIZADOPORUID");

            migrationBuilder.CreateIndex(
                name: "IX_USUARIOPERFIL_FINALIZADOPORUID",
                table: "USUARIOPERFIL",
                column: "FINALIZADOPORUID");

            migrationBuilder.CreateIndex(
                name: "IX_USUARIOPERFIL_PERFILUID",
                table: "USUARIOPERFIL",
                column: "PERFILUID");

            migrationBuilder.CreateIndex(
                name: "IX_USUARIOPERFIL_PROJETOUID",
                table: "USUARIOPERFIL",
                column: "PROJETOUID");

            migrationBuilder.CreateIndex(
                name: "IX_USUARIOPERFIL_USUARIOCRIADORUID",
                table: "USUARIOPERFIL",
                column: "USUARIOCRIADORUID");

            migrationBuilder.CreateIndex(
                name: "IX_USUARIOPERFIL_USUARIOUID",
                table: "USUARIOPERFIL",
                column: "USUARIOUID");

            migrationBuilder.CreateIndex(
                name: "IX_USUARIOS_ATUALIZADOPORUID",
                table: "USUARIOS",
                column: "ATUALIZADOPORUID");

            migrationBuilder.CreateIndex(
                name: "IX_USUARIOS_FINALIZADOPORUID",
                table: "USUARIOS",
                column: "FINALIZADOPORUID");

            migrationBuilder.CreateIndex(
                name: "IX_USUARIOS_USUARIOCRIADORUID",
                table: "USUARIOS",
                column: "USUARIOCRIADORUID");

            migrationBuilder.Sql(@"
                CREATE TRIGGER LocalizacoesDeletada
                ON LOCALIZACOES
                AFTER UPDATE
                AS
                BEGIN
                    IF UPDATE(DATAFINALIZACAO)
                    BEGIN
                        UPDATE COMPONENTES
                        SET DATAFINALIZACAO = inserted.DATAFINALIZACAO,
                        FINALIZADOPORUID = inserted.FINALIZADOPORUID
                        FROM COMPONENTES
                        INNER JOIN inserted ON COMPONENTES.LOCALIZACAOUID = inserted.UID;

                        UPDATE EQUIPAMENTOS
                        SET DATAFINALIZACAO = inserted.DATAFINALIZACAO,
                        FINALIZADOPORUID = inserted.FINALIZADOPORUID
                        FROM EQUIPAMENTOS
                        INNER JOIN inserted ON EQUIPAMENTOS.LOCALIZACAOUID = inserted.UID;
                    END
                END
            ");

            //Finaliza componentes e seus dependentes.
            migrationBuilder.Sql(@"
                CREATE TRIGGER ComponentesDeletado
                ON COMPONENTES
                AFTER UPDATE
                AS
                BEGIN
                    IF UPDATE(DATAFINALIZACAO)
                    BEGIN
                        UPDATE EQUIPAMENTOS
                        SET DATAFINALIZACAO = inserted.DATAFINALIZACAO,
                        FINALIZADOPORUID = inserted.FINALIZADOPORUID
                        FROM EQUIPAMENTOS
                        INNER JOIN inserted ON EQUIPAMENTOS.COMPONENTEUID = inserted.UID;

                        UPDATE SOFTWARES
                        SET DATAFINALIZACAO = inserted.DATAFINALIZACAO,
                        FINALIZADOPORUID = inserted.FINALIZADOPORUID
                        FROM SOFTWARES
                        INNER JOIN inserted ON SOFTWARES.COMPONENTEUID = inserted.UID;

                        UPDATE MANUTENCOES
                        SET DATAFINALIZACAO = inserted.DATAFINALIZACAO,
                        FINALIZADOPORUID = inserted.FINALIZADOPORUID
                        FROM MANUTENCOES
                        INNER JOIN inserted ON MANUTENCOES.COMPONENTEUID = inserted.UID;
                    END
                END
            ");

            migrationBuilder.Sql(@"
                CREATE TRIGGER UsuariosDeletado
                ON USUARIOS
                AFTER UPDATE
                AS
                BEGIN
                    IF UPDATE(DATAFINALIZACAO)
                    BEGIN
                        UPDATE USUARIOPERFIL
                        SET DATAFINALIZACAO = inserted.DATAFINALIZACAO,
                        FINALIZADOPORUID = inserted.FINALIZADOPORUID
                        FROM USUARIOPERFIL
                        INNER JOIN inserted ON USUARIOPERFIL.USUARIOUID = inserted.UID;
                    END
                END
            ");

            migrationBuilder.Sql(@"
                CREATE TRIGGER ManutencoesDeletado
                ON MANUTENCOES
                AFTER UPDATE
                AS
                BEGIN
                    IF UPDATE(DATAFINALIZACAO)
                    BEGIN
                        UPDATE ATRIBUICOES
                        SET DATAFINALIZACAO = inserted.DATAFINALIZACAO,
                        FINALIZADOPORUID = inserted.FINALIZADOPORUID
                        FROM ATRIBUICOES
                        INNER JOIN inserted ON ATRIBUICOES.OBJETOUID = inserted.UID;
                    END
                END
            ");

            migrationBuilder.Sql(@"
                CREATE TRIGGER RequisicoesDeletado
                ON REQUISICOES
                AFTER UPDATE
                AS
                BEGIN
                    IF UPDATE(DATAFINALIZACAO)
                    BEGIN
                        UPDATE ATRIBUICOES
                        SET DATAFINALIZACAO = inserted.DATAFINALIZACAO,
                        FINALIZADOPORUID = inserted.FINALIZADOPORUID
                        FROM ATRIBUICOES
                        INNER JOIN inserted ON ATRIBUICOES.OBJETOUID = inserted.UID;
                    END
                END
            ");

            migrationBuilder.Sql(@"
                CREATE TRIGGER ProjetosDeletado
                ON PROJETOS
                AFTER UPDATE
                AS
                BEGIN
                    IF UPDATE(DATAFINALIZACAO)
                    BEGIN
                        UPDATE COMPONENTES
                        SET DATAFINALIZACAO = inserted.DATAFINALIZACAO,
                        FINALIZADOPORUID = inserted.FINALIZADOPORUID
                        FROM COMPONENTES
                        INNER JOIN inserted ON COMPONENTES.PROJETOUID = inserted.UID;

                        UPDATE LOCALIZACOES
                        SET DATAFINALIZACAO = inserted.DATAFINALIZACAO,
                        FINALIZADOPORUID = inserted.FINALIZADOPORUID
                        FROM LOCALIZACOES
                        INNER JOIN inserted ON LOCALIZACOES.PROJETOUID = inserted.UID;

                        UPDATE EQUIPAMENTOS
                        SET DATAFINALIZACAO = inserted.DATAFINALIZACAO,
                        FINALIZADOPORUID = inserted.FINALIZADOPORUID
                        FROM EQUIPAMENTOS
                        INNER JOIN inserted ON EQUIPAMENTOS.PROJETOUID = inserted.UID;

                        UPDATE SOFTWARES
                        SET DATAFINALIZACAO = inserted.DATAFINALIZACAO,
                        FINALIZADOPORUID = inserted.FINALIZADOPORUID
                        FROM SOFTWARES
                        INNER JOIN inserted ON SOFTWARES.PROJETOUID = inserted.UID;

                        UPDATE MANUTENCOES
                        SET DATAFINALIZACAO = inserted.DATAFINALIZACAO,
                        FINALIZADOPORUID = inserted.FINALIZADOPORUID
                        FROM MANUTENCOES
                        INNER JOIN inserted ON MANUTENCOES.PROJETOUID = inserted.UID;

                        UPDATE REQUISICOES
                        SET DATAFINALIZACAO = inserted.DATAFINALIZACAO,
                        FINALIZADOPORUID = inserted.FINALIZADOPORUID
                        FROM REQUISICOES
                        INNER JOIN inserted ON REQUISICOES.PROJETOUID = inserted.UID;
                    END
                END
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ATRIBUICOES");

            migrationBuilder.DropTable(
                name: "EQUIPAMENTOS");

            migrationBuilder.DropTable(
                name: "MANUTENCOES");

            migrationBuilder.DropTable(
                name: "NOTIFICACOES");

            migrationBuilder.DropTable(
                name: "REQUISICOES");

            migrationBuilder.DropTable(
                name: "SOFTWARES");

            migrationBuilder.DropTable(
                name: "USUARIOPERFIL");

            migrationBuilder.DropTable(
                name: "COMPONENTES");

            migrationBuilder.DropTable(
                name: "PERFIS");

            migrationBuilder.DropTable(
                name: "LOCALIZACOES");

            migrationBuilder.DropTable(
                name: "PROJETOS");

            migrationBuilder.DropTable(
                name: "USUARIOS");
        }
    }
}
