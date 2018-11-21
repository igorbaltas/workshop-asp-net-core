using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HelpDeskMvc.Migrations
{
    public partial class dbInventario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inventario",
                columns: table => new
                {
                    idMaquina = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    hostNameMaquina = table.Column<string>(nullable: true),
                    sistemaMaquina = table.Column<string>(nullable: true),
                    tipoEquipamento = table.Column<string>(nullable: true),
                    cpuMaquina = table.Column<string>(nullable: true),
                    memoriaMaquina = table.Column<string>(nullable: true),
                    localMaquina = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventario", x => x.idMaquina);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inventario");
        }
    }
}
