using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cuisine.Migrations
{
    public partial class LesBasesCuisines : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Plat",
                columns: table => new
                {
                    PlatsID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Temps_Moyen_Preparation_Plat = table.Column<int>(type: "int", nullable: false),
                    Taille_Plat_Moyen = table.Column<int>(type: "int", nullable: false),
                    Vide = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plat", x => x.PlatsID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Plat");
        }
    }
}
