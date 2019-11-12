using Microsoft.EntityFrameworkCore.Migrations;

namespace GaaClub.Data.Migrations
{
    public partial class UpdateMemberId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Member",
                newName: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Member",
                newName: "Id");
        }
    }
}
