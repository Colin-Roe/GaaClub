using Microsoft.EntityFrameworkCore.Migrations;

namespace GaaClub.Migrations
{
    public partial class UpdateMember : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address1",
                table: "Members",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address2",
                table: "Members",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address3",
                table: "Members",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address4",
                table: "Members",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Members",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "FeePaid",
                table: "Members",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPlayer",
                table: "Members",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "MatchOfficial",
                table: "Members",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Members",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostCode",
                table: "Members",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address1",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "Address2",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "Address3",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "Address4",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "FeePaid",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "IsPlayer",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "MatchOfficial",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "PostCode",
                table: "Members");
        }
    }
}
