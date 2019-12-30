using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace animalShelter.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "Cat",
                table => new
                {
                    CatID = table.Column<int>()
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(),
                    Dob = table.Column<DateTime>(),
                    Breed = table.Column<string>(),
                    Sex = table.Column<string>(),
                    Summary = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Cat", x => x.CatID); });

            migrationBuilder.CreateTable(
                "Dog",
                table => new
                {
                    DogID = table.Column<int>()
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(),
                    Dob = table.Column<DateTime>(),
                    Breed = table.Column<string>(),
                    Sex = table.Column<string>(),
                    Summary = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true),
                    MainImagePath = table.Column<string>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Dog", x => x.DogID); });

            migrationBuilder.CreateTable(
                "User",
                table => new
                {
                    ID = table.Column<int>()
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(),
                    LastName = table.Column<string>(),
                    AddressLine1 = table.Column<string>(),
                    Postcode = table.Column<string>(),
                    Email = table.Column<string>(),
                    Telephone = table.Column<string>(),
                    IsAdmin = table.Column<bool>()
                },
                constraints: table => { table.PrimaryKey("PK_User", x => x.ID); });

            migrationBuilder.CreateTable(
                "Adoption",
                table => new
                {
                    DogAdoptionID = table.Column<int>()
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DogID = table.Column<int>(),
                    UserID = table.Column<int>(),
                    AdoptionDate = table.Column<DateTime>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adoption", x => x.DogAdoptionID);
                    table.ForeignKey(
                        "FK_Adoption_Dog_DogID",
                        x => x.DogID,
                        "Dog",
                        "DogID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_Adoption_User_UserID",
                        x => x.UserID,
                        "User",
                        "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "CatAdoption",
                table => new
                {
                    CatAdoptionID = table.Column<int>()
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CatID = table.Column<int>(),
                    UserID = table.Column<int>(),
                    AdoptionDate = table.Column<DateTime>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatAdoption", x => x.CatAdoptionID);
                    table.ForeignKey(
                        "FK_CatAdoption_Cat_CatID",
                        x => x.CatID,
                        "Cat",
                        "CatID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_CatAdoption_User_UserID",
                        x => x.UserID,
                        "User",
                        "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                "IX_Adoption_DogID",
                "Adoption",
                "DogID");

            migrationBuilder.CreateIndex(
                "IX_Adoption_UserID",
                "Adoption",
                "UserID");

            migrationBuilder.CreateIndex(
                "IX_CatAdoption_CatID",
                "CatAdoption",
                "CatID");

            migrationBuilder.CreateIndex(
                "IX_CatAdoption_UserID",
                "CatAdoption",
                "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "Adoption");

            migrationBuilder.DropTable(
                "CatAdoption");

            migrationBuilder.DropTable(
                "Dog");

            migrationBuilder.DropTable(
                "Cat");

            migrationBuilder.DropTable(
                "User");
        }
    }
}