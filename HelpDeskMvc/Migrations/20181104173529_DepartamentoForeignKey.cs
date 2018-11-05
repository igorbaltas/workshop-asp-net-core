using Microsoft.EntityFrameworkCore.Migrations;

namespace HelpDeskMvc.Migrations
{
    public partial class DepartamentoForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Departamento_departamentoidDpto",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_departamentoidDpto",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "departamentoidDpto",
                table: "Usuario");

            migrationBuilder.AddColumn<int>(
                name: "DepartamentoId",
                table: "Usuario",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_DepartamentoId",
                table: "Usuario",
                column: "DepartamentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Departamento_DepartamentoId",
                table: "Usuario",
                column: "DepartamentoId",
                principalTable: "Departamento",
                principalColumn: "idDpto",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Departamento_DepartamentoId",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_DepartamentoId",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "DepartamentoId",
                table: "Usuario");

            migrationBuilder.AddColumn<int>(
                name: "departamentoidDpto",
                table: "Usuario",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_departamentoidDpto",
                table: "Usuario",
                column: "departamentoidDpto");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Departamento_departamentoidDpto",
                table: "Usuario",
                column: "departamentoidDpto",
                principalTable: "Departamento",
                principalColumn: "idDpto",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
