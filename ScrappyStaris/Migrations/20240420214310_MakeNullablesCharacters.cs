using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScrappyStaris.Migrations
{
    /// <inheritdoc />
    public partial class MakeNullablesCharacters : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Planets_HomeWorldId",
                table: "Characters");

            migrationBuilder.AlterColumn<int>(
                name: "HomeWorldId",
                table: "Characters",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Planets_HomeWorldId",
                table: "Characters",
                column: "HomeWorldId",
                principalTable: "Planets",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Planets_HomeWorldId",
                table: "Characters");

            migrationBuilder.AlterColumn<int>(
                name: "HomeWorldId",
                table: "Characters",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Planets_HomeWorldId",
                table: "Characters",
                column: "HomeWorldId",
                principalTable: "Planets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
