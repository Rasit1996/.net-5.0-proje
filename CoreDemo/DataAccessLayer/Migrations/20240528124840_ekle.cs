using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class ekle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.AddColumn<string>(name:"UserID",table:"bloks",type:"int",nullable:true);

           
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.DropColumn(
			   name: "UserID",
			   table: "bloks");
		}
    }
}
