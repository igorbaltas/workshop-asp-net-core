using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HelpDeskMvc.Migrations
{
    public partial class OtherEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Chamado",
                columns: table => new
                {
                    idChamado = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    status = table.Column<int>(nullable: false),
                    descricaoChamado = table.Column<string>(nullable: true),
                    dataAbertura = table.Column<DateTime>(nullable: false),
                    dataEncerramento = table.Column<DateTime>(nullable: false),
                    solucaoChamado = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chamado", x => x.idChamado);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    idUsuario = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nomeUsuario = table.Column<string>(nullable: true),
                    loginUsuario = table.Column<string>(nullable: true),
                    senhaUsuario = table.Column<string>(nullable: true),
                    situacaoUsuario = table.Column<string>(nullable: true),
                    nvlAcesso = table.Column<string>(nullable: true),
                    departamentoidDpto = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.idUsuario);
                    table.ForeignKey(
                        name: "FK_Usuario_Departamento_departamentoidDpto",
                        column: x => x.departamentoidDpto,
                        principalTable: "Departamento",
                        principalColumn: "idDpto",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_departamentoidDpto",
                table: "Usuario",
                column: "departamentoidDpto");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Chamado");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
