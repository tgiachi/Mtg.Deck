using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mtg.Deck.Database.Migrations
{
    public partial class CardTableUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "cards",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ManaCost",
                table: "cards",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "MtgId",
                table: "cards",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "cards",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "cards");

            migrationBuilder.DropColumn(
                name: "ManaCost",
                table: "cards");

            migrationBuilder.DropColumn(
                name: "MtgId",
                table: "cards");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "cards");
        }
    }
}
