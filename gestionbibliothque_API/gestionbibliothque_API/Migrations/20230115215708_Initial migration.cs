using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace gestionbibliothque_API.Migrations
{
    public partial class Initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Auteurs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodeLivre = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auteurs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeLivres",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeLivres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Livre",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Langue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    maisonEdition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    imageLivreURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nbpage = table.Column<int>(type: "int", nullable: false),
                    prixAchat = table.Column<int>(type: "int", nullable: false),
                    AnneEdition = table.Column<int>(type: "int", nullable: false),
                    IdTypeLivre = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TypeLivreId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AuteursId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livre", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Livre_Auteurs_AuteursId",
                        column: x => x.AuteursId,
                        principalTable: "Auteurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Livre_TypeLivres_TypeLivreId",
                        column: x => x.TypeLivreId,
                        principalTable: "TypeLivres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Livre_AuteursId",
                table: "Livre",
                column: "AuteursId");

            migrationBuilder.CreateIndex(
                name: "IX_Livre_TypeLivreId",
                table: "Livre",
                column: "TypeLivreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Livre");

            migrationBuilder.DropTable(
                name: "Auteurs");

            migrationBuilder.DropTable(
                name: "TypeLivres");
        }
    }
}
