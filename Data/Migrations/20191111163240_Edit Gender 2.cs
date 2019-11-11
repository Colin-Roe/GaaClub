using Microsoft.EntityFrameworkCore.Migrations;

namespace GaaClub.Data.Migrations
{
    public partial class EditGender2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "Gender",
                table: "Member",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Gender",
                table: "Member",
                type: "int",
                nullable: false,
                oldClrType: typeof(byte));
        }
    }
}
