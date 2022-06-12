using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mtg.Deck.Database.Migrations
{
    public partial class ModifiedCardsColors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CardEntityColorEntity");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "cards",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "TEXT");

            migrationBuilder.CreateTable(
                name: "CardColors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CardId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ColorId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardColors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CardColors_cards_CardId",
                        column: x => x.CardId,
                        principalTable: "cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CardColors_colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "colors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CardColors_CardId",
                table: "CardColors",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_CardColors_ColorId",
                table: "CardColors",
                column: "ColorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CardColors");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "cards",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "CardEntityColorEntity",
                columns: table => new
                {
                    CardsId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ColorsId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardEntityColorEntity", x => new { x.CardsId, x.ColorsId });
                    table.ForeignKey(
                        name: "FK_CardEntityColorEntity_cards_CardsId",
                        column: x => x.CardsId,
                        principalTable: "cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CardEntityColorEntity_colors_ColorsId",
                        column: x => x.ColorsId,
                        principalTable: "colors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CardEntityColorEntity_ColorsId",
                table: "CardEntityColorEntity",
                column: "ColorsId");
        }
    }
}
