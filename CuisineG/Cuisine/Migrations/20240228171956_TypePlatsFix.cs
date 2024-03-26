using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cuisine.Migrations
{
    public partial class TypePlatsFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plat_TypePlats_TypePlatsTypePlatID",
                table: "Plat");

            migrationBuilder.DropIndex(
                name: "IX_Plat_TypePlatsTypePlatID",
                table: "Plat");

            migrationBuilder.DropColumn(
                name: "TypePlatsTypePlatID",
                table: "Plat");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Plat",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Plat");

            migrationBuilder.AddColumn<int>(
                name: "TypePlatsTypePlatID",
                table: "Plat",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Plat_TypePlatsTypePlatID",
                table: "Plat",
                column: "TypePlatsTypePlatID");

            migrationBuilder.AddForeignKey(
                name: "FK_Plat_TypePlats_TypePlatsTypePlatID",
                table: "Plat",
                column: "TypePlatsTypePlatID",
                principalTable: "TypePlats",
                principalColumn: "TypePlatID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
