using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HelpDeskMvc.Migrations
{
    public partial class AddServico : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "servicosidServico",
                table: "Chamado",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Servico",
                columns: table => new
                {
                    idServico = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    dsServico = table.Column<string>(nullable: true),
                    slaServico = table.Column<string>(nullable: true),
                    criticidadeServico = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servico", x => x.idServico);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chamado_Servico_servicosidServico",
                table: "Chamado");

            migrationBuilder.DropTable(
                name: "Servico");

            migrationBuilder.DropIndex(
                name: "IX_Chamado_servicosidServico",
                table: "Chamado");

            migrationBuilder.DropColumn(
                name: "servicosidServico",
                table: "Chamado");
        }
    }
}
