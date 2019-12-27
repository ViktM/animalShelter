using Microsoft.EntityFrameworkCore.Migrations;

namespace animalShelter.Migrations
{
    public partial class CatChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Dog");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Cat");

            migrationBuilder.AddColumn<string>(
                name: "MainImagePath",
                table: "Cat",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MainImagePath",
                table: "Cat");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Dog",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Cat",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}