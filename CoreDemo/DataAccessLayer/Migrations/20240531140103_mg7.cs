using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class mg7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_bildirims_userID",
                table: "bildirims",
                column: "userID");

            migrationBuilder.AddForeignKey(
                name: "FK_bildirims_AspNetUsers_userID",
                table: "bildirims",
                column: "userID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bildirims_AspNetUsers_userID",
                table: "bildirims");

            migrationBuilder.DropIndex(
                name: "IX_bildirims_userID",
                table: "bildirims");
        }
    }
}
