using Microsoft.EntityFrameworkCore.Migrations;

namespace HelpDeskMvc.Migrations
{
    public partial class newnew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chamado_Servico_servicosidServico",
                table: "Chamado");

            migrationBuilder.DropIndex(
                name: "IX_Chamado_servicosidServico",
                table: "Chamado");

            migrationBuilder.DropColumn(
                name: "servicosidServico",
                table: "Chamado");

            migrationBuilder.AddColumn<int>(
                name: "servicoId",
                table: "Chamado",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Chamado_servicoId",
                table: "Chamado",
                column: "servicoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Chamado_Servico_servicoId",
                table: "Chamado",
                column: "servicoId",
                principalTable: "Servico",
                principalColumn: "idServico",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chamado_Servico_servicoId",
                table: "Chamado");

            migrationBuilder.DropIndex(
                name: "IX_Chamado_servicoId",
                table: "Chamado");

            migrationBuilder.DropColumn(
                name: "servicoId",
                table: "Chamado");

            migrationBuilder.AddColumn<int>(
                name: "servicosidServico",
                table: "Chamado",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Chamado_servicosidServico",
                table: "Chamado",
                column: "servicosidServico");

            migrationBuilder.AddForeignKey(
                name: "FK_Chamado_Servico_servicosidServico",
                table: "Chamado",
                column: "servicosidServico",
                principalTable: "Servico",
                principalColumn: "idServico",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
