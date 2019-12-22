using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace animalShelter.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cat",
                columns: table => new
                {
                    CatID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Dob = table.Column<DateTime>(nullable: false),
                    Breed = table.Column<string>(nullable: false),
                    Sex = table.Column<string>(nullable: false),
                    Summary = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cat", x => x.CatID);
                });

            migrationBuilder.CreateTable(
                name: "Dog",
                columns: table => new
                {
                    DogID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Dob = table.Column<DateTime>(nullable: false),
                    Breed = table.Column<string>(nullable: false),
                    Sex = table.Column<string>(nullable: false),
                    Summary = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true),
                    MainImagePath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dog", x => x.DogID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    AddressLine1 = table.Column<string>(nullable: false),
                    Postcode = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Telephone = table.Column<string>(nullable: false),
                    IsAdmin = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Adoption",
                columns: table => new
                {
                    DogAdoptionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DogID = table.Column<int>(nullable: false),
                    UserID = table.Column<int>(nullable: false),
                    AdoptionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adoption", x => x.DogAdoptionID);
                    table.ForeignKey(
                        name: "FK_Adoption_Dog_DogID",
                        column: x => x.DogID,
                        principalTable: "Dog",
                        principalColumn: "DogID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Adoption_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CatAdoption",
                columns: table => new
                {
                    CatAdoptionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CatID = table.Column<int>(nullable: false),
                    UserID = table.Column<int>(nullable: false),
                    AdoptionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatAdoption", x => x.CatAdoptionID);
                    table.ForeignKey(
                        name: "FK_CatAdoption_Cat_CatID",
                        column: x => x.CatID,
                        principalTable: "Cat",
                        principalColumn: "CatID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CatAdoption_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adoption_DogID",
                table: "Adoption",
                column: "DogID");

            migrationBuilder.CreateIndex(
                name: "IX_Adoption_UserID",
                table: "Adoption",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_CatAdoption_CatID",
                table: "CatAdoption",
                column: "CatID");

            migrationBuilder.CreateIndex(
                name: "IX_CatAdoption_UserID",
                table: "CatAdoption",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adoption");

            migrationBuilder.DropTable(
                name: "CatAdoption");

            migrationBuilder.DropTable(
                name: "Dog");

            migrationBuilder.DropTable(
                name: "Cat");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
