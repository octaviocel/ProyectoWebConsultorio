using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoConsultorio.Data.Migrations
{
    public partial class dos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "fecha1",
                table: "Cita",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "fecha1",
                table: "Cita");
        }
    }
}
