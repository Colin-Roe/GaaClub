using Microsoft.EntityFrameworkCore.Migrations;

namespace GaaClub.Data.Migrations
{
    public partial class EditGender3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Gender",
                table: "Member",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "Gender",
                table: "Member",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
