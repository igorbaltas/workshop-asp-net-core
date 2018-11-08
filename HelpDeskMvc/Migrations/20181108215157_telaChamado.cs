using Microsoft.EntityFrameworkCore.Migrations;

namespace HelpDeskMvc.Migrations
{
    public partial class telaChamado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ServicoidServico",
                table: "Servico",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DepartamentoId",
                table: "Chamado",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Servico_ServicoidServico",
                table: "Servico",
                column: "ServicoidServico");

            migrationBuilder.CreateIndex(
                name: "IX_Chamado_DepartamentoId",
                table: "Chamado",
                column: "DepartamentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Chamado_Departamento_DepartamentoId",
                table: "Chamado",
                column: "DepartamentoId",
                principalTable: "Departamento",
                principalColumn: "idDpto",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Servico_Servico_ServicoidServico",
                table: "Servico",
                column: "ServicoidServico",
                principalTable: "Servico",
                principalColumn: "idServico",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chamado_Departamento_DepartamentoId",
                table: "Chamado");

            migrationBuilder.DropForeignKey(
                name: "FK_Servico_Servico_ServicoidServico",
                table: "Servico");

            migrationBuilder.DropIndex(
                name: "IX_Servico_ServicoidServico",
                table: "Servico");

            migrationBuilder.DropIndex(
                name: "IX_Chamado_DepartamentoId",
                table: "Chamado");

            migrationBuilder.DropColumn(
                name: "ServicoidServico",
                table: "Servico");

            migrationBuilder.DropColumn(
                name: "DepartamentoId",
                table: "Chamado");
        }
    }
}
