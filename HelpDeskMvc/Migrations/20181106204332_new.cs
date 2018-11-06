using Microsoft.EntityFrameworkCore.Migrations;

namespace HelpDeskMvc.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "senhaUsuario",
                table: "Usuario",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "nvlAcesso",
                table: "Usuario",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "nomeUsuario",
                table: "Usuario",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "loginUsuario",
                table: "Usuario",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Chamado",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "tecnicoId",
                table: "Chamado",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Chamado_UsuarioId",
                table: "Chamado",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Chamado_Usuario_UsuarioId",
                table: "Chamado",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "idUsuario",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chamado_Usuario_UsuarioId",
                table: "Chamado");

            migrationBuilder.DropIndex(
                name: "IX_Chamado_UsuarioId",
                table: "Chamado");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Chamado");

            migrationBuilder.DropColumn(
                name: "tecnicoId",
                table: "Chamado");

            migrationBuilder.AlterColumn<string>(
                name: "senhaUsuario",
                table: "Usuario",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "nvlAcesso",
                table: "Usuario",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "nomeUsuario",
                table: "Usuario",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "loginUsuario",
                table: "Usuario",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100);

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
    }
}
