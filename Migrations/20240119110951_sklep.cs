using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hypta_Projekt.Migrations
{
    /// <inheritdoc />
    public partial class sklep : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kategorie",
                columns: table => new
                {
                    KategoriaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategorie", x => x.KategoriaID);
                });

            migrationBuilder.CreateTable(
                name: "Klienci",
                columns: table => new
                {
                    KlientID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nazwisko = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klienci", x => x.KlientID);
                });

            migrationBuilder.CreateTable(
                name: "Produkty",
                columns: table => new
                {
                    ProduktID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cena = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produkty", x => x.ProduktID);
                });

            migrationBuilder.CreateTable(
                name: "ProduktKategorie",
                columns: table => new
                {
                    ProduktKategoriaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KategoriaID = table.Column<int>(type: "int", nullable: false),
                    ProduktID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProduktKategorie", x => x.ProduktKategoriaID);
                    table.ForeignKey(
                        name: "FK_ProduktKategorie_Kategorie_KategoriaID",
                        column: x => x.KategoriaID,
                        principalTable: "Kategorie",
                        principalColumn: "KategoriaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProduktKategorie_Produkty_ProduktID",
                        column: x => x.ProduktID,
                        principalTable: "Produkty",
                        principalColumn: "ProduktID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Zamowienia",
                columns: table => new
                {
                    ZamowienieID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataZamowienia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatusZamowienia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProduktID = table.Column<int>(type: "int", nullable: false),
                    KlientID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zamowienia", x => x.ZamowienieID);
                    table.ForeignKey(
                        name: "FK_Zamowienia_Klienci_KlientID",
                        column: x => x.KlientID,
                        principalTable: "Klienci",
                        principalColumn: "KlientID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Zamowienia_Produkty_ProduktID",
                        column: x => x.ProduktID,
                        principalTable: "Produkty",
                        principalColumn: "ProduktID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProduktKategorie_KategoriaID",
                table: "ProduktKategorie",
                column: "KategoriaID");

            migrationBuilder.CreateIndex(
                name: "IX_ProduktKategorie_ProduktID",
                table: "ProduktKategorie",
                column: "ProduktID");

            migrationBuilder.CreateIndex(
                name: "IX_Zamowienia_KlientID",
                table: "Zamowienia",
                column: "KlientID");

            migrationBuilder.CreateIndex(
                name: "IX_Zamowienia_ProduktID",
                table: "Zamowienia",
                column: "ProduktID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProduktKategorie");

            migrationBuilder.DropTable(
                name: "Zamowienia");

            migrationBuilder.DropTable(
                name: "Kategorie");

            migrationBuilder.DropTable(
                name: "Klienci");

            migrationBuilder.DropTable(
                name: "Produkty");
        }
    }
}
