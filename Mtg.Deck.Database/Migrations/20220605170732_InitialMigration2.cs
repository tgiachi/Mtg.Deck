using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mtg.Deck.Database.Migrations
{
    public partial class InitialMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CardEntityColorEntity_Cards_CardsId",
                table: "CardEntityColorEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_CardEntityColorEntity_Colors_ColorsId",
                table: "CardEntityColorEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_Cards_CardTypes_CardTypeId",
                table: "Cards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Colors",
                table: "Colors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cards",
                table: "Cards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CardTypes",
                table: "CardTypes");

            migrationBuilder.RenameTable(
                name: "Colors",
                newName: "colors");

            migrationBuilder.RenameTable(
                name: "Cards",
                newName: "cards");

            migrationBuilder.RenameTable(
                name: "CardTypes",
                newName: "card_types");

            migrationBuilder.RenameIndex(
                name: "IX_Cards_CardTypeId",
                table: "cards",
                newName: "IX_cards_CardTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_colors",
                table: "colors",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_cards",
                table: "cards",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_card_types",
                table: "card_types",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CardEntityColorEntity_cards_CardsId",
                table: "CardEntityColorEntity",
                column: "CardsId",
                principalTable: "cards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CardEntityColorEntity_colors_ColorsId",
                table: "CardEntityColorEntity",
                column: "ColorsId",
                principalTable: "colors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_cards_card_types_CardTypeId",
                table: "cards",
                column: "CardTypeId",
                principalTable: "card_types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CardEntityColorEntity_cards_CardsId",
                table: "CardEntityColorEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_CardEntityColorEntity_colors_ColorsId",
                table: "CardEntityColorEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_cards_card_types_CardTypeId",
                table: "cards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_colors",
                table: "colors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_cards",
                table: "cards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_card_types",
                table: "card_types");

            migrationBuilder.RenameTable(
                name: "colors",
                newName: "Colors");

            migrationBuilder.RenameTable(
                name: "cards",
                newName: "Cards");

            migrationBuilder.RenameTable(
                name: "card_types",
                newName: "CardTypes");

            migrationBuilder.RenameIndex(
                name: "IX_cards_CardTypeId",
                table: "Cards",
                newName: "IX_Cards_CardTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Colors",
                table: "Colors",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cards",
                table: "Cards",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CardTypes",
                table: "CardTypes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CardEntityColorEntity_Cards_CardsId",
                table: "CardEntityColorEntity",
                column: "CardsId",
                principalTable: "Cards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CardEntityColorEntity_Colors_ColorsId",
                table: "CardEntityColorEntity",
                column: "ColorsId",
                principalTable: "Colors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_CardTypes_CardTypeId",
                table: "Cards",
                column: "CardTypeId",
                principalTable: "CardTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
