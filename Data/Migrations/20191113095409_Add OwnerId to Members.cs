using Microsoft.EntityFrameworkCore.Migrations;

namespace GaaClub.Data.Migrations
{
    public partial class AddOwnerIdtoMembers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OwnerId",
                table: "Member",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Member");
        }
    }
}
