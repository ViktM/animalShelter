using Microsoft.EntityFrameworkCore.Migrations;

namespace animalShelter.Migrations
{
    public partial class CatChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                "ImageUrl",
                "Dog");

            migrationBuilder.DropColumn(
                "ImageUrl",
                "Cat");

            migrationBuilder.AddColumn<string>(
                "MainImagePath",
                "Cat",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                "MainImagePath",
                "Cat");

            migrationBuilder.AddColumn<string>(
                "ImageUrl",
                "Dog",
                "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                "ImageUrl",
                "Cat",
                "nvarchar(max)",
                nullable: true);
        }
    }
}