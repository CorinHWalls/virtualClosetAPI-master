using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace virtualCloset.Migrations
{
    public partial class updatedalltables1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Brand",
                table: "OutfitInfo");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "OutfitInfo");

            migrationBuilder.DropColumn(
                name: "Color",
                table: "OutfitInfo");

            migrationBuilder.DropColumn(
                name: "Season",
                table: "OutfitInfo");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "OutfitInfo");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "OutfitInfo",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "ItemInfo",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "OutfitInfo",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ItemInfo",
                newName: "id");

            migrationBuilder.AddColumn<string>(
                name: "Brand",
                table: "OutfitInfo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "OutfitInfo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "OutfitInfo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Season",
                table: "OutfitInfo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Size",
                table: "OutfitInfo",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
