using Microsoft.EntityFrameworkCore.Migrations;

namespace GaaClub.Migrations
{
    public partial class NewChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Members_FeeTypes_FeeTypeFeeID",
                table: "Members");

            migrationBuilder.DropIndex(
                name: "IX_Members_FeeTypeFeeID",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "FeeTypeFeeID",
                table: "Members");

            migrationBuilder.CreateIndex(
                name: "IX_Members_FeeID",
                table: "Members",
                column: "FeeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Members_FeeTypes_FeeID",
                table: "Members",
                column: "FeeID",
                principalTable: "FeeTypes",
                principalColumn: "FeeID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Members_FeeTypes_FeeID",
                table: "Members");

            migrationBuilder.DropIndex(
                name: "IX_Members_FeeID",
                table: "Members");

            migrationBuilder.AddColumn<int>(
                name: "FeeTypeFeeID",
                table: "Members",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Members_FeeTypeFeeID",
                table: "Members",
                column: "FeeTypeFeeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Members_FeeTypes_FeeTypeFeeID",
                table: "Members",
                column: "FeeTypeFeeID",
                principalTable: "FeeTypes",
                principalColumn: "FeeID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
