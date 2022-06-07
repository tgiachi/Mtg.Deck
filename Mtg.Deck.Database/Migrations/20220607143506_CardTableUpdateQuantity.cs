using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mtg.Deck.Database.Migrations
{
    public partial class CardTableUpdateQuantity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "cards",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "cards");
        }
    }
}
