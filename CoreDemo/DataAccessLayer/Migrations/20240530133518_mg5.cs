using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class mg5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MesajUser_AspNetUsers_AliciID",
                table: "MesajUser");

            migrationBuilder.DropForeignKey(
                name: "FK_MesajUser_AspNetUsers_GonderenID",
                table: "MesajUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MesajUser",
                table: "MesajUser");

            migrationBuilder.RenameTable(
                name: "MesajUser",
                newName: "mesajUsers");

            migrationBuilder.RenameIndex(
                name: "IX_MesajUser_GonderenID",
                table: "mesajUsers",
                newName: "IX_mesajUsers_GonderenID");

            migrationBuilder.RenameIndex(
                name: "IX_MesajUser_AliciID",
                table: "mesajUsers",
                newName: "IX_mesajUsers_AliciID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_mesajUsers",
                table: "mesajUsers",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_mesajUsers_AspNetUsers_AliciID",
                table: "mesajUsers",
                column: "AliciID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_mesajUsers_AspNetUsers_GonderenID",
                table: "mesajUsers",
                column: "GonderenID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_mesajUsers_AspNetUsers_AliciID",
                table: "mesajUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_mesajUsers_AspNetUsers_GonderenID",
                table: "mesajUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_mesajUsers",
                table: "mesajUsers");

            migrationBuilder.RenameTable(
                name: "mesajUsers",
                newName: "MesajUser");

            migrationBuilder.RenameIndex(
                name: "IX_mesajUsers_GonderenID",
                table: "MesajUser",
                newName: "IX_MesajUser_GonderenID");

            migrationBuilder.RenameIndex(
                name: "IX_mesajUsers_AliciID",
                table: "MesajUser",
                newName: "IX_MesajUser_AliciID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MesajUser",
                table: "MesajUser",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_MesajUser_AspNetUsers_AliciID",
                table: "MesajUser",
                column: "AliciID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MesajUser_AspNetUsers_GonderenID",
                table: "MesajUser",
                column: "GonderenID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
