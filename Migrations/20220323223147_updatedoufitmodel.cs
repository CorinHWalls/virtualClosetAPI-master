using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace virtualCloset.Migrations
{
    public partial class updatedoufitmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OutfitId",
                table: "ItemInfo");

            migrationBuilder.RenameColumn(
                name: "OutfitSeason",
                table: "OutfitInfo",
                newName: "Size");

            migrationBuilder.RenameColumn(
                name: "OutfitOccasion",
                table: "OutfitInfo",
                newName: "Selected");

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
                name: "Favorite",
                table: "OutfitInfo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "OutfitInfo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Season",
                table: "OutfitInfo",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "Favorite",
                table: "OutfitInfo");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "OutfitInfo");

            migrationBuilder.DropColumn(
                name: "Season",
                table: "OutfitInfo");

            migrationBuilder.RenameColumn(
                name: "Size",
                table: "OutfitInfo",
                newName: "OutfitSeason");

            migrationBuilder.RenameColumn(
                name: "Selected",
                table: "OutfitInfo",
                newName: "OutfitOccasion");

            migrationBuilder.AddColumn<int>(
                name: "OutfitId",
                table: "ItemInfo",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
