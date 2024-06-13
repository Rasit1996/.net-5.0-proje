using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class mggg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_bloks_UserID",
                table: "bloks",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_bloks_AspNetUsers_UserID",
                table: "bloks",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bloks_AspNetUsers_UserID",
                table: "bloks");

            migrationBuilder.DropIndex(
                name: "IX_bloks_UserID",
                table: "bloks");
        }
    }
}
