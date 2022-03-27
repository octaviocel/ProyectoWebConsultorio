using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoConsultorio.Data.Migrations
{
    public partial class Hola1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdAreaMedica",
                table: "AreaMedica",
                newName: "IdArea");

            migrationBuilder.AddColumn<int>(
                name: "Id_AreaMedica",
                table: "Cita",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Cita_Id_AreaMedica",
                table: "Cita",
                column: "Id_AreaMedica");

            migrationBuilder.AddForeignKey(
                name: "FK_Cita_AreaMedica_Id_AreaMedica",
                table: "Cita",
                column: "Id_AreaMedica",
                principalTable: "AreaMedica",
                principalColumn: "IdArea",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cita_AreaMedica_Id_AreaMedica",
                table: "Cita");

            migrationBuilder.DropIndex(
                name: "IX_Cita_Id_AreaMedica",
                table: "Cita");

            migrationBuilder.DropColumn(
                name: "Id_AreaMedica",
                table: "Cita");

            migrationBuilder.RenameColumn(
                name: "IdArea",
                table: "AreaMedica",
                newName: "IdAreaMedica");
        }
    }
}
