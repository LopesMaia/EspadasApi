using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EspadasApi.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Espadas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Familia = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Forca = table.Column<int>(type: "int", nullable: false),
                    Durabilidade = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Espadas", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Espadas",
                columns: new[] { "Id", "Durabilidade", "Familia", "Forca", "Nome" },
                values: new object[] { 1, 100.0, "Flame", 71, "Cimitarra" });

            migrationBuilder.InsertData(
                table: "Espadas",
                columns: new[] { "Id", "Durabilidade", "Familia", "Forca", "Nome" },
                values: new object[] { 2, 100.0, "Dark", 41, "Alfange" });

            migrationBuilder.InsertData(
                table: "Espadas",
                columns: new[] { "Id", "Durabilidade", "Familia", "Forca", "Nome" },
                values: new object[] { 3, 94.209999999999994, "Dark", 65, "Montante" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Espadas");
        }
    }
}
