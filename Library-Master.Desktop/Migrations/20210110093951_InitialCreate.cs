using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Library_Master.Desktop.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QrCode",
                columns: table => new
                {
                    QrCodeId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Titel = table.Column<string>(type: "TEXT", nullable: true),
                    Kuerzel = table.Column<string>(type: "TEXT", nullable: true),
                    Isbn = table.Column<string>(type: "TEXT", nullable: true),
                    Besonderheit = table.Column<string>(type: "TEXT", nullable: true),
                    QrCodeString = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QrCode", x => x.QrCodeId);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Medium = table.Column<string>(type: "TEXT", nullable: true),
                    Titel = table.Column<string>(type: "TEXT", nullable: true),
                    Fach = table.Column<string>(type: "TEXT", nullable: true),
                    Verlag = table.Column<string>(type: "TEXT", nullable: true),
                    Besonderheit = table.Column<string>(type: "TEXT", nullable: true),
                    Entliehen = table.Column<bool>(type: "INTEGER", nullable: false),
                    HinzufuegeDatum = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Sparte = table.Column<string>(type: "TEXT", nullable: true),
                    Klasse = table.Column<string>(type: "TEXT", nullable: true),
                    Kategorie = table.Column<string>(type: "TEXT", nullable: true),
                    Preis = table.Column<double>(type: "REAL", nullable: false),
                    Informationen = table.Column<string>(type: "TEXT", nullable: true),
                    Nummer = table.Column<string>(type: "TEXT", nullable: true),
                    AutorKuerzel = table.Column<string>(type: "TEXT", nullable: true),
                    Autor = table.Column<string>(type: "TEXT", nullable: true),
                    Antolin = table.Column<bool>(type: "INTEGER", nullable: false),
                    Bezugsquelle = table.Column<string>(type: "TEXT", nullable: true),
                    Isbn = table.Column<string>(type: "TEXT", nullable: true),
                    ErscheinungsJahr = table.Column<string>(type: "TEXT", nullable: true),
                    QrCodeId = table.Column<int>(type: "INTEGER", nullable: true),
                    ZuletztEntliehen = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ZuletztEntliehenVon = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookId);
                    table.ForeignKey(
                        name: "FK_Books_QrCode_QrCodeId",
                        column: x => x.QrCodeId,
                        principalTable: "QrCode",
                        principalColumn: "QrCodeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_QrCodeId",
                table: "Books",
                column: "QrCodeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "QrCode");
        }
    }
}
