using Microsoft.EntityFrameworkCore.Migrations;

namespace GaaClub.Migrations
{
    public partial class FeeTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FeeId",
                table: "Members",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FeeTypeID",
                table: "Members",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FeeTypes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(maxLength: 20, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    FeeCost = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeeTypes", x => x.ID);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Members_FeeTypes_FeeTypeID",
                table: "Members");

            migrationBuilder.DropTable(
                name: "FeeTypes");

            migrationBuilder.DropIndex(
                name: "IX_Members_FeeTypeID",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "FeeId",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "FeeTypeID",
                table: "Members");
        }
    }
}
