using Microsoft.EntityFrameworkCore.Migrations;

namespace GaaClub.Migrations
{
    public partial class NullableFeeID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Members_FeeTypes_FeeID",
                table: "Members");

            migrationBuilder.AlterColumn<int>(
                name: "FeeID",
                table: "Members",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Members_FeeTypes_FeeID",
                table: "Members",
                column: "FeeID",
                principalTable: "FeeTypes",
                principalColumn: "FeeID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Members_FeeTypes_FeeID",
                table: "Members");

            migrationBuilder.AlterColumn<int>(
                name: "FeeID",
                table: "Members",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Members_FeeTypes_FeeID",
                table: "Members",
                column: "FeeID",
                principalTable: "FeeTypes",
                principalColumn: "FeeID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
