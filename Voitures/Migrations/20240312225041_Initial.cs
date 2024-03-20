using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Voitures.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Voitures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Marque = table.Column<string>(type: "TEXT", nullable: true),
                    Modele = table.Column<string>(type: "TEXT", nullable: true),
                    Immatriculation = table.Column<string>(type: "TEXT", nullable: true),
                    Annee = table.Column<int>(type: "INTEGER", nullable: false),
                    Kilometrage = table.Column<int>(type: "INTEGER", nullable: false),
                    Energie = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voitures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Entretiens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Kilometrage = table.Column<int>(type: "INTEGER", nullable: false),
                    DescritionEntretien = table.Column<string>(type: "TEXT", nullable: true),
                    VoitureId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entretiens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Entretiens_Voitures_VoitureId",
                        column: x => x.VoitureId,
                        principalTable: "Voitures",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Entretiens_VoitureId",
                table: "Entretiens",
                column: "VoitureId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Entretiens");

            migrationBuilder.DropTable(
                name: "Voitures");
        }
    }
}
