using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AmadeusWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class ChangeAirlinesIdentification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Identificacion",
                table: "Airlines",
                newName: "Identification");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Identification",
                table: "Airlines",
                newName: "Identificacion");
        }
    }
}
