using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Library_Master.EntityFramework.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QrCodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Titel = table.Column<string>(type: "TEXT", nullable: true),
                    Verlag = table.Column<string>(type: "TEXT", nullable: true),
                    Author = table.Column<string>(type: "TEXT", nullable: true),
                    Isbn = table.Column<string>(type: "TEXT", nullable: true),
                    Info = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QrCodes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdentId = table.Column<int>(type: "INTEGER", nullable: false),
                    Klasse = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AccountHolderId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accounts_Users_AccountHolderId",
                        column: x => x.AccountHolderId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
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
                    StrPreis = table.Column<string>(type: "TEXT", nullable: true),
                    Informationen = table.Column<string>(type: "TEXT", nullable: true),
                    Nummer = table.Column<string>(type: "TEXT", nullable: true),
                    AutorKuerzel = table.Column<string>(type: "TEXT", nullable: true),
                    Autor = table.Column<string>(type: "TEXT", nullable: true),
                    StrAntolin = table.Column<string>(type: "TEXT", nullable: true),
                    Antolin = table.Column<bool>(type: "INTEGER", nullable: false),
                    Bezugsquelle = table.Column<string>(type: "TEXT", nullable: true),
                    Isbn = table.Column<string>(type: "TEXT", nullable: true),
                    ErscheinungsJahr = table.Column<string>(type: "TEXT", nullable: true),
                    QrCodeId = table.Column<int>(type: "INTEGER", nullable: true),
                    ZuletztEntliehen = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ZuletztEntliehenVonId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Accounts_ZuletztEntliehenVonId",
                        column: x => x.ZuletztEntliehenVonId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Books_QrCodes_QrCodeId",
                        column: x => x.QrCodeId,
                        principalTable: "QrCodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EntliehenAm = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EntliehenVonId = table.Column<int>(type: "INTEGER", nullable: true),
                    AbgabeAm = table.Column<DateTime>(type: "TEXT", nullable: false),
                    BookId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_Accounts_EntliehenVonId",
                        column: x => x.EntliehenVonId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transactions_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_AccountHolderId",
                table: "Accounts",
                column: "AccountHolderId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_QrCodeId",
                table: "Books",
                column: "QrCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_ZuletztEntliehenVonId",
                table: "Books",
                column: "ZuletztEntliehenVonId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_BookId",
                table: "Transactions",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_EntliehenVonId",
                table: "Transactions",
                column: "EntliehenVonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "QrCodes");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
