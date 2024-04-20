using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScrappyStaris.Migrations
{
    /// <inheritdoc />
    public partial class Test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterPlanet_Characters_CharacterId",
                table: "CharacterPlanet");

            migrationBuilder.DropIndex(
                name: "IX_CharacterPlanet_CharacterId",
                table: "CharacterPlanet");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_CharacterPlanet_CharacterId",
                table: "CharacterPlanet",
                column: "CharacterId");

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterPlanet_Characters_CharacterId",
                table: "CharacterPlanet",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
