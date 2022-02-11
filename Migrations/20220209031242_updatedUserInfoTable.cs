using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace virtualCloset.Migrations
{
    public partial class updatedUserInfoTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "UserInfo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "UserInfo",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "UserInfo");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "UserInfo");
        }
    }
}
