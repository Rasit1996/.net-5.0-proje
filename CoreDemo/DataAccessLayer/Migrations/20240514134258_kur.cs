using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class kur : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.CreateTable(
                name: "mesaj2s",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GonderenID = table.Column<int>(type: "int", nullable: false),
                    AliciID = table.Column<int>(type: "int", nullable: false),
                    Konu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Icerik = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Durum = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mesaj2s", x => x.ID);
                    table.ForeignKey(
                        name: "FK_mesaj2s_yazars_AliciID",
                        column: x => x.AliciID,
                        principalTable: "yazars",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_mesaj2s_yazars_GonderenID",
                        column: x => x.GonderenID,
                        principalTable: "yazars",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });


            migrationBuilder.CreateIndex(
                name: "IX_mesaj2s_AliciID",
                table: "mesaj2s",
                column: "AliciID");

            migrationBuilder.CreateIndex(
                name: "IX_mesaj2s_GonderenID",
                table: "mesaj2s",
                column: "GonderenID");

          
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.DropTable(
                name: "mesaj2s");

        }
    }
}
