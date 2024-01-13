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
                name: "CICLOSVIDA",
                columns: table => new
                {
                    UID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OBJETOUID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NOME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DESCRICAO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ATUALIZADOPOR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DATAULTIMAATUALIZACAO = table.Column<DateTime>(type: "datetime2", nullable: true),
                    USUARIOCRIADOR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DATACRIACAO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FINALIZADOPOR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DATAFINALIZACAO = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CICLOSVIDA", x => x.UID);
                });

            migrationBuilder.CreateTable(
                name: "LOCALIZACOES",
                columns: table => new
                {
                    UID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NOME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DESCRICAO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ATUALIZADOPOR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DATAULTIMAATUALIZACAO = table.Column<DateTime>(type: "datetime2", nullable: true),
                    USUARIOCRIADOR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DATACRIACAO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FINALIZADOPOR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DATAFINALIZACAO = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LOCALIZACOES", x => x.UID);
                });

            migrationBuilder.CreateTable(
                name: "PERFIS",
                columns: table => new
                {
                    UID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NOME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DESCRICAO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ATUALIZADOPOR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DATAULTIMAATUALIZACAO = table.Column<DateTime>(type: "datetime2", nullable: true),
                    USUARIOCRIADOR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DATACRIACAO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FINALIZADOPOR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DATAFINALIZACAO = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PERFIS", x => x.UID);
                });

            migrationBuilder.CreateTable(
                name: "PROJETOS",
                columns: table => new
                {
                    UID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NOME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DESCRICAO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ATUALIZADOPOR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DATAULTIMAATUALIZACAO = table.Column<DateTime>(type: "datetime2", nullable: true),
                    USUARIOCRIADOR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DATACRIACAO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FINALIZADOPOR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DATAFINALIZACAO = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PROJETOS", x => x.UID);
                });

            migrationBuilder.CreateTable(
                name: "USUARIOS",
                columns: table => new
                {
                    UID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NOMEACESSO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SENHA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NOME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DESCRICAO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ATUALIZADOPOR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DATAULTIMAATUALIZACAO = table.Column<DateTime>(type: "datetime2", nullable: true),
                    USUARIOCRIADOR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DATACRIACAO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FINALIZADOPOR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DATAFINALIZACAO = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIOS", x => x.UID);
                });

            migrationBuilder.CreateTable(
                name: "CICLOVIDAPASSOS",
                columns: table => new
                {
                    UID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CICLOVIDAUID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PASSOFALHAUID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PASSOSUCESSOUID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TIPO = table.Column<int>(type: "int", nullable: false),
                    NOME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DESCRICAO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ATUALIZADOPOR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DATAULTIMAATUALIZACAO = table.Column<DateTime>(type: "datetime2", nullable: true),
                    USUARIOCRIADOR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DATACRIACAO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FINALIZADOPOR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DATAFINALIZACAO = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CICLOVIDAPASSOS", x => x.UID);
                    table.ForeignKey(
                        name: "FK_CICLOVIDAPASSOS_CICLOSVIDA_CICLOVIDAUID",
                        column: x => x.CICLOVIDAUID,
                        principalTable: "CICLOSVIDA",
                        principalColumn: "UID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "COMPONENTES",
                columns: table => new
                {
                    UID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NUMEROSERIE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LOCALIZACAOUID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    STATUS = table.Column<int>(type: "int", nullable: false),
                    MARCA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MODELO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TIPO = table.Column<int>(type: "int", nullable: false),
                    DATAAQUISICAO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NOME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DESCRICAO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ATUALIZADOPOR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DATAULTIMAATUALIZACAO = table.Column<DateTime>(type: "datetime2", nullable: true),
                    USUARIOCRIADOR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DATACRIACAO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FINALIZADOPOR = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NOTIFICACOES",
                columns: table => new
                {
                    UID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    USUARIOUID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NOME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DESCRICAO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ATUALIZADOPOR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DATAULTIMAATUALIZACAO = table.Column<DateTime>(type: "datetime2", nullable: true),
                    USUARIOCRIADOR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DATACRIACAO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FINALIZADOPOR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DATAFINALIZACAO = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NOTIFICACOES", x => x.UID);
                    table.ForeignKey(
                        name: "FK_NOTIFICACOES_USUARIOS_USUARIOUID",
                        column: x => x.USUARIOUID,
                        principalTable: "USUARIOS",
                        principalColumn: "UID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "REQUISICOES",
                columns: table => new
                {
                    UID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    COORDENADORUID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NOME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DESCRICAO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ATUALIZADOPOR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DATAULTIMAATUALIZACAO = table.Column<DateTime>(type: "datetime2", nullable: true),
                    USUARIOCRIADOR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DATACRIACAO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FINALIZADOPOR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DATAFINALIZACAO = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_REQUISICOES", x => x.UID);
                    table.ForeignKey(
                        name: "FK_REQUISICOES_USUARIOS_COORDENADORUID",
                        column: x => x.COORDENADORUID,
                        principalTable: "USUARIOS",
                        principalColumn: "UID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "USUARIOPROJETOPERFIL",
                columns: table => new
                {
                    USUARIOUID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PROJETOUID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PERFILUID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ATIVADO = table.Column<bool>(type: "bit", nullable: false),
                    ATUALIZADOPOR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DATAULTIMAATUALIZACAO = table.Column<DateTime>(type: "datetime2", nullable: true),
                    USUARIOCRIADOR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DATACRIACAO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FINALIZADOPOR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DATAFINALIZACAO = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIOPROJETOPERFIL", x => new { x.PROJETOUID, x.USUARIOUID, x.PERFILUID });
                    table.ForeignKey(
                        name: "FK_USUARIOPROJETOPERFIL_PERFIS_PERFILUID",
                        column: x => x.PERFILUID,
                        principalTable: "PERFIS",
                        principalColumn: "UID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_USUARIOPROJETOPERFIL_PROJETOS_PROJETOUID",
                        column: x => x.PROJETOUID,
                        principalTable: "PROJETOS",
                        principalColumn: "UID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_USUARIOPROJETOPERFIL_USUARIOS_USUARIOUID",
                        column: x => x.USUARIOUID,
                        principalTable: "USUARIOS",
                        principalColumn: "UID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ATRIBUICOES",
                columns: table => new
                {
                    UID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    USUARIOUID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CICLOVIDAPASSOUID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TIPO = table.Column<int>(type: "int", nullable: false),
                    NOME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DESCRICAO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ATUALIZADOPOR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DATAULTIMAATUALIZACAO = table.Column<DateTime>(type: "datetime2", nullable: true),
                    USUARIOCRIADOR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DATACRIACAO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FINALIZADOPOR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DATAFINALIZACAO = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ATRIBUICOES", x => x.UID);
                    table.ForeignKey(
                        name: "FK_ATRIBUICOES_CICLOVIDAPASSOS_CICLOVIDAPASSOUID",
                        column: x => x.CICLOVIDAPASSOUID,
                        principalTable: "CICLOVIDAPASSOS",
                        principalColumn: "UID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ATRIBUICOES_USUARIOS_USUARIOUID",
                        column: x => x.USUARIOUID,
                        principalTable: "USUARIOS",
                        principalColumn: "UID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EQUIPAMENTOS",
                columns: table => new
                {
                    UID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NUMEROSERIE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LOCALIZACAOUID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    COMPONENTEUID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MARCA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MODELO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TIPO = table.Column<int>(type: "int", nullable: false),
                    DATAAQUISICAO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NOME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DESCRICAO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ATUALIZADOPOR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DATAULTIMAATUALIZACAO = table.Column<DateTime>(type: "datetime2", nullable: true),
                    USUARIOCRIADOR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DATACRIACAO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FINALIZADOPOR = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MANUTENCOES",
                columns: table => new
                {
                    UID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    COMPONENTEUID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DATAINICIO = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DATATERMINO = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RESPONSAVELUID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SOLUCAO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NOME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DESCRICAO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ATUALIZADOPOR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DATAULTIMAATUALIZACAO = table.Column<DateTime>(type: "datetime2", nullable: true),
                    USUARIOCRIADOR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DATACRIACAO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FINALIZADOPOR = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MANUTENCOES_USUARIOS_RESPONSAVELUID",
                        column: x => x.RESPONSAVELUID,
                        principalTable: "USUARIOS",
                        principalColumn: "UID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SOFTWARES",
                columns: table => new
                {
                    UID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LOCALIZACAOUID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    COMPONENTEUID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CHAVELICENCA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DATAVENCIMENTO = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NOME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DESCRICAO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ATUALIZADOPOR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DATAULTIMAATUALIZACAO = table.Column<DateTime>(type: "datetime2", nullable: true),
                    USUARIOCRIADOR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DATACRIACAO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FINALIZADOPOR = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SOFTWARES_LOCALIZACOES_LOCALIZACAOUID",
                        column: x => x.LOCALIZACAOUID,
                        principalTable: "LOCALIZACOES",
                        principalColumn: "UID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ATRIBUICOES_CICLOVIDAPASSOUID",
                table: "ATRIBUICOES",
                column: "CICLOVIDAPASSOUID");

            migrationBuilder.CreateIndex(
                name: "IX_ATRIBUICOES_USUARIOUID",
                table: "ATRIBUICOES",
                column: "USUARIOUID");

            migrationBuilder.CreateIndex(
                name: "IX_CICLOVIDAPASSOS_CICLOVIDAUID",
                table: "CICLOVIDAPASSOS",
                column: "CICLOVIDAUID");

            migrationBuilder.CreateIndex(
                name: "IX_COMPONENTES_LOCALIZACAOUID",
                table: "COMPONENTES",
                column: "LOCALIZACAOUID");

            migrationBuilder.CreateIndex(
                name: "IX_EQUIPAMENTOS_COMPONENTEUID",
                table: "EQUIPAMENTOS",
                column: "COMPONENTEUID");

            migrationBuilder.CreateIndex(
                name: "IX_MANUTENCOES_COMPONENTEUID",
                table: "MANUTENCOES",
                column: "COMPONENTEUID");

            migrationBuilder.CreateIndex(
                name: "IX_MANUTENCOES_RESPONSAVELUID",
                table: "MANUTENCOES",
                column: "RESPONSAVELUID");

            migrationBuilder.CreateIndex(
                name: "IX_NOTIFICACOES_USUARIOUID",
                table: "NOTIFICACOES",
                column: "USUARIOUID");

            migrationBuilder.CreateIndex(
                name: "IX_REQUISICOES_COORDENADORUID",
                table: "REQUISICOES",
                column: "COORDENADORUID");

            migrationBuilder.CreateIndex(
                name: "IX_SOFTWARES_COMPONENTEUID",
                table: "SOFTWARES",
                column: "COMPONENTEUID");

            migrationBuilder.CreateIndex(
                name: "IX_SOFTWARES_LOCALIZACAOUID",
                table: "SOFTWARES",
                column: "LOCALIZACAOUID");

            migrationBuilder.CreateIndex(
                name: "IX_USUARIOPROJETOPERFIL_PERFILUID",
                table: "USUARIOPROJETOPERFIL",
                column: "PERFILUID");

            migrationBuilder.CreateIndex(
                name: "IX_USUARIOPROJETOPERFIL_USUARIOUID",
                table: "USUARIOPROJETOPERFIL",
                column: "USUARIOUID");
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
                name: "USUARIOPROJETOPERFIL");

            migrationBuilder.DropTable(
                name: "CICLOVIDAPASSOS");

            migrationBuilder.DropTable(
                name: "COMPONENTES");

            migrationBuilder.DropTable(
                name: "PERFIS");

            migrationBuilder.DropTable(
                name: "PROJETOS");

            migrationBuilder.DropTable(
                name: "USUARIOS");

            migrationBuilder.DropTable(
                name: "CICLOSVIDA");

            migrationBuilder.DropTable(
                name: "LOCALIZACOES");
        }
    }
}
