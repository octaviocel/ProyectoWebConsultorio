using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoConsultorio.Data.Migrations
{
    public partial class Hola : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AreaMedica",
                columns: table => new
                {
                    IdAreaMedica = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Area = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreaMedica", x => x.IdAreaMedica);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AreaMedica");
        }
    }
}
