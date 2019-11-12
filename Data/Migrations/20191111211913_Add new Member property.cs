using Microsoft.EntityFrameworkCore.Migrations;

namespace GaaClub.Data.Migrations
{
    public partial class AddnewMemberproperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Member",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Member");
        }
    }
}
