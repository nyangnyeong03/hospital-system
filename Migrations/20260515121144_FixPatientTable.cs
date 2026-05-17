using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CahwciHospital.Migrations
{
    /// <inheritdoc />
    public partial class FixPatientTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nationality",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Service",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Sex",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nationality",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Service",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Sex",
                table: "Patients");
        }
    }
}
