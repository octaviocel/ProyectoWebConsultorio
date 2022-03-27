using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoConsultorio.Data.Migrations
{
    public partial class firts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Empleado",
                columns: table => new
                {
                    IdEmpleado = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleado", x => x.IdEmpleado);
                });

            migrationBuilder.CreateTable(
                name: "Paciente",
                columns: table => new
                {
                    Id_paciente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApellidoPat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApellidoMat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sexo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RFC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoSangre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaNac = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Alcoholismo = table.Column<bool>(type: "bit", nullable: false),
                    Tabaquismo = table.Column<bool>(type: "bit", nullable: false),
                    Toxicaomania = table.Column<bool>(type: "bit", nullable: false),
                    Dirección = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CURP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aseguradora = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paciente", x => x.Id_paciente);
                });

            migrationBuilder.CreateTable(
                name: "Cita",
                columns: table => new
                {
                    IdCitas = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Hora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Id_paciente = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cita", x => x.IdCitas);
                    table.ForeignKey(
                        name: "FK_Cita_Paciente_Id_paciente",
                        column: x => x.Id_paciente,
                        principalTable: "Paciente",
                        principalColumn: "Id_paciente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Consulta",
                columns: table => new
                {
                    Id_consulta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Peso = table.Column<float>(type: "real", nullable: false),
                    Altura = table.Column<float>(type: "real", nullable: false),
                    Presion1 = table.Column<int>(type: "int", nullable: false),
                    Presion2 = table.Column<int>(type: "int", nullable: false),
                    Id_paciente = table.Column<int>(type: "int", nullable: false),
                    Sintomas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Diagnostico = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Medicamentos = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consulta", x => x.Id_consulta);
                    table.ForeignKey(
                        name: "FK_Consulta_Paciente_Id_paciente",
                        column: x => x.Id_paciente,
                        principalTable: "Paciente",
                        principalColumn: "Id_paciente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Expediente",
                columns: table => new
                {
                    Id_expediente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PacienteId = table.Column<int>(type: "int", nullable: false),
                    EmpleadoId = table.Column<int>(type: "int", nullable: false),
                    Presion1 = table.Column<int>(type: "int", nullable: false),
                    Presion2 = table.Column<int>(type: "int", nullable: false),
                    Peso = table.Column<float>(type: "real", nullable: false),
                    Altura = table.Column<float>(type: "real", nullable: false),
                    CronicoDegenerativa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Operaciones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Alergias = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Reflejos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Movimientos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expediente", x => x.Id_expediente);
                    table.ForeignKey(
                        name: "FK_Expediente_Empleado_EmpleadoId",
                        column: x => x.EmpleadoId,
                        principalTable: "Empleado",
                        principalColumn: "IdEmpleado",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Expediente_Paciente_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Paciente",
                        principalColumn: "Id_paciente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cita_Id_paciente",
                table: "Cita",
                column: "Id_paciente");

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_Id_paciente",
                table: "Consulta",
                column: "Id_paciente");

            migrationBuilder.CreateIndex(
                name: "IX_Expediente_EmpleadoId",
                table: "Expediente",
                column: "EmpleadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Expediente_PacienteId",
                table: "Expediente",
                column: "PacienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cita");

            migrationBuilder.DropTable(
                name: "Consulta");

            migrationBuilder.DropTable(
                name: "Expediente");

            migrationBuilder.DropTable(
                name: "Empleado");

            migrationBuilder.DropTable(
                name: "Paciente");
        }
    }
}
