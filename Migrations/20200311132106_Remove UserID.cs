using Microsoft.EntityFrameworkCore.Migrations;

namespace GaaClub.Migrations
{
    public partial class RemoveUserID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Members");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Members",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
