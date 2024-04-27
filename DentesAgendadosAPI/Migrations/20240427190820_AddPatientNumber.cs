using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DentesAgendadosAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddPatientNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NumeroPaciente",
                table: "Agendamentos",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumeroPaciente",
                table: "Agendamentos");
        }
    }
}
