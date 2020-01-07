using Microsoft.EntityFrameworkCore.Migrations;

namespace GaaClub.Migrations
{
    public partial class EditFeeType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Members_FeeTypes_FeeTypeID",
                table: "Members");

            migrationBuilder.DropIndex(
                name: "IX_Members_FeeTypeID",
                table: "Members");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FeeTypes",
                table: "FeeTypes");

            migrationBuilder.DropColumn(
                name: "FeeTypeID",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "FeeTypes");

            migrationBuilder.RenameColumn(
                name: "FeeId",
                table: "Members",
                newName: "FeeID");

            migrationBuilder.AddColumn<int>(
                name: "FeeTypeFeeID",
                table: "Members",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FeeID",
                table: "FeeTypes",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FeeTypes",
                table: "FeeTypes",
                column: "FeeID");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Members_FeeTypes_FeeTypeFeeID",
                table: "Members");

            migrationBuilder.DropIndex(
                name: "IX_Members_FeeTypeFeeID",
                table: "Members");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FeeTypes",
                table: "FeeTypes");

            migrationBuilder.DropColumn(
                name: "FeeTypeFeeID",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "FeeID",
                table: "FeeTypes");

            migrationBuilder.RenameColumn(
                name: "FeeID",
                table: "Members",
                newName: "FeeId");

            migrationBuilder.AddColumn<int>(
                name: "FeeTypeID",
                table: "Members",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "FeeTypes",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FeeTypes",
                table: "FeeTypes",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_Members_FeeTypeID",
                table: "Members",
                column: "FeeTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Members_FeeTypes_FeeTypeID",
                table: "Members",
                column: "FeeTypeID",
                principalTable: "FeeTypes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
