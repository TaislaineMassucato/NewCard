using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewCard.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Especialidade",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especialidade", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Paciente",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    telefone = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    endereco = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    data_nascimento = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paciente", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Medico",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    EspecialidadeId = table.Column<int>(type: "int", nullable: true),
                    telefone = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    email = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    EspecialidadeId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medico", x => x.id);
                    table.ForeignKey(
                        name: "FK_Medico_Especialidade",
                        column: x => x.EspecialidadeId,
                        principalTable: "Especialidade",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Medico_Especialidade_EspecialidadeId1",
                        column: x => x.EspecialidadeId1,
                        principalTable: "Especialidade",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Mensagem",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    data_envio = table.Column<DateTime>(type: "date", nullable: true),
                    hora_envio = table.Column<TimeSpan>(type: "time", nullable: true),
                    DestinatarioId = table.Column<int>(type: "int", nullable: true),
                    tipo = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    PacienteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mensagem", x => x.id);
                    table.ForeignKey(
                        name: "FK_Mensagem_Paciente",
                        column: x => x.DestinatarioId,
                        principalTable: "Paciente",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Mensagem_Paciente_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Paciente",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Consulta",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    data_consulta = table.Column<DateTime>(type: "date", nullable: true),
                    hora_consulta = table.Column<TimeSpan>(type: "time", nullable: true),
                    MedicoId = table.Column<int>(type: "int", nullable: true),
                    PacienteId = table.Column<int>(type: "int", nullable: true),
                    status = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    MedicoId1 = table.Column<int>(type: "int", nullable: true),
                    PacienteId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consulta", x => x.id);
                    table.ForeignKey(
                        name: "FK_Consulta_Medico",
                        column: x => x.MedicoId,
                        principalTable: "Medico",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Consulta_Medico_MedicoId1",
                        column: x => x.MedicoId1,
                        principalTable: "Medico",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Consulta_Paciente",
                        column: x => x.PacienteId,
                        principalTable: "Paciente",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Consulta_Paciente_PacienteId1",
                        column: x => x.PacienteId1,
                        principalTable: "Paciente",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "HistoricoConsulta",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    data_consulta = table.Column<DateTime>(type: "date", nullable: true),
                    hora_consulta = table.Column<TimeSpan>(type: "time", nullable: true),
                    MedicoId = table.Column<int>(type: "int", nullable: true),
                    PacienteId = table.Column<int>(type: "int", nullable: true),
                    diagnostico = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    prescricao = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    MedicoId1 = table.Column<int>(type: "int", nullable: true),
                    PacienteId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricoConsulta", x => x.id);
                    table.ForeignKey(
                        name: "FK_HistoricoConsulta_Medico",
                        column: x => x.MedicoId,
                        principalTable: "Medico",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_HistoricoConsulta_Medico_MedicoId1",
                        column: x => x.MedicoId1,
                        principalTable: "Medico",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_HistoricoConsulta_Paciente",
                        column: x => x.PacienteId,
                        principalTable: "Paciente",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_HistoricoConsulta_Paciente_PacienteId1",
                        column: x => x.PacienteId1,
                        principalTable: "Paciente",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_MedicoId",
                table: "Consulta",
                column: "MedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_MedicoId1",
                table: "Consulta",
                column: "MedicoId1");

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_PacienteId",
                table: "Consulta",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_PacienteId1",
                table: "Consulta",
                column: "PacienteId1");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoConsulta_MedicoId",
                table: "HistoricoConsulta",
                column: "MedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoConsulta_MedicoId1",
                table: "HistoricoConsulta",
                column: "MedicoId1");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoConsulta_PacienteId",
                table: "HistoricoConsulta",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoConsulta_PacienteId1",
                table: "HistoricoConsulta",
                column: "PacienteId1");

            migrationBuilder.CreateIndex(
                name: "IX_Medico_EspecialidadeId",
                table: "Medico",
                column: "EspecialidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Medico_EspecialidadeId1",
                table: "Medico",
                column: "EspecialidadeId1");

            migrationBuilder.CreateIndex(
                name: "IX_Mensagem_DestinatarioId",
                table: "Mensagem",
                column: "DestinatarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Mensagem_PacienteId",
                table: "Mensagem",
                column: "PacienteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Consulta");

            migrationBuilder.DropTable(
                name: "Funcionarios");

            migrationBuilder.DropTable(
                name: "HistoricoConsulta");

            migrationBuilder.DropTable(
                name: "Mensagem");

            migrationBuilder.DropTable(
                name: "Medico");

            migrationBuilder.DropTable(
                name: "Paciente");

            migrationBuilder.DropTable(
                name: "Especialidade");
        }
    }
}
