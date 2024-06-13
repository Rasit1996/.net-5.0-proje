using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class mg3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bloks_yazars_YazarID",
                table: "bloks");

            migrationBuilder.DropIndex(
                name: "IX_bloks_YazarID",
                table: "bloks");

            migrationBuilder.DropColumn(
                name: "YazarID",
                table: "bloks");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "YazarID",
                table: "bloks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_bloks_YazarID",
                table: "bloks",
                column: "YazarID");

            migrationBuilder.AddForeignKey(
                name: "FK_bloks_yazars_YazarID",
                table: "bloks",
                column: "YazarID",
                principalTable: "yazars",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
