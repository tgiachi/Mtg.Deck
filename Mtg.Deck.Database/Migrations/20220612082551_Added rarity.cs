using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mtg.Deck.Database.Migrations
{
    public partial class Addedrarity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "RarityId",
                table: "cards",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "rarity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rarity", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cards_RarityId",
                table: "cards",
                column: "RarityId");

            migrationBuilder.AddForeignKey(
                name: "FK_cards_rarity_RarityId",
                table: "cards",
                column: "RarityId",
                principalTable: "rarity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cards_rarity_RarityId",
                table: "cards");

            migrationBuilder.DropTable(
                name: "rarity");

            migrationBuilder.DropIndex(
                name: "IX_cards_RarityId",
                table: "cards");

            migrationBuilder.DropColumn(
                name: "RarityId",
                table: "cards");
        }
    }
}
