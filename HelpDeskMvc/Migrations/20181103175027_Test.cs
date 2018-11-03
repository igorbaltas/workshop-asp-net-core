using Microsoft.EntityFrameworkCore.Migrations;

namespace HelpDeskMvc.Migrations
{
    public partial class Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "usuariosidUsuario",
                table: "Chamado",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Chamado_usuariosidUsuario",
                table: "Chamado",
                column: "usuariosidUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Chamado_Usuario_usuariosidUsuario",
                table: "Chamado",
                column: "usuariosidUsuario",
                principalTable: "Usuario",
                principalColumn: "idUsuario",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chamado_Usuario_usuariosidUsuario",
                table: "Chamado");

            migrationBuilder.DropIndex(
                name: "IX_Chamado_usuariosidUsuario",
                table: "Chamado");

            migrationBuilder.DropColumn(
                name: "usuariosidUsuario",
                table: "Chamado");
        }
    }
}
