using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace virtualCloset.Migrations
{
    public partial class updatedItemModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Favorite",
                table: "ItemInfo",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "ItemInfo",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Favorite",
                table: "ItemInfo");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "ItemInfo");
        }
    }
}
