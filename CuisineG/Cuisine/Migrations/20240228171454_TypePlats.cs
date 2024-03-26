using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cuisine.Migrations
{
    public partial class TypePlats : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TypePlatsTypePlatID",
                table: "Plat",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TypePlats",
                columns: table => new
                {
                    TypePlatID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Chance = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypePlats", x => x.TypePlatID);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plat_TypePlats_TypePlatsTypePlatID",
                table: "Plat");

            migrationBuilder.DropTable(
                name: "TypePlats");

            migrationBuilder.DropIndex(
                name: "IX_Plat_TypePlatsTypePlatID",
                table: "Plat");

            migrationBuilder.DropColumn(
                name: "TypePlatsTypePlatID",
                table: "Plat");
        }
    }
}
