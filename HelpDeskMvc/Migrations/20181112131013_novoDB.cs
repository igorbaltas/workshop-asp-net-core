using Microsoft.EntityFrameworkCore.Migrations;

namespace HelpDeskMvc.Migrations
{
    public partial class novoDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Chamado_tecnicoId",
                table: "Chamado",
                column: "tecnicoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Chamado_Usuario_tecnicoId",
                table: "Chamado",
                column: "tecnicoId",
                principalTable: "Usuario",
                principalColumn: "idUsuario",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chamado_Usuario_tecnicoId",
                table: "Chamado");

            migrationBuilder.DropIndex(
                name: "IX_Chamado_tecnicoId",
                table: "Chamado");
        }
    }
}
