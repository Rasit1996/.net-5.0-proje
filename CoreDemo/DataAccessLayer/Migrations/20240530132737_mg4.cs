using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class mg4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MesajUser",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GonderenID = table.Column<int>(type: "int", nullable: false),
                    AliciID = table.Column<int>(type: "int", nullable: false),
                    Konu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Icerik = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    durum = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MesajUser", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MesajUser_AspNetUsers_AliciID",
                        column: x => x.AliciID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MesajUser_AspNetUsers_GonderenID",
                        column: x => x.GonderenID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MesajUser_AliciID",
                table: "MesajUser",
                column: "AliciID");

            migrationBuilder.CreateIndex(
                name: "IX_MesajUser_GonderenID",
                table: "MesajUser",
                column: "GonderenID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MesajUser");
        }
    }
}
