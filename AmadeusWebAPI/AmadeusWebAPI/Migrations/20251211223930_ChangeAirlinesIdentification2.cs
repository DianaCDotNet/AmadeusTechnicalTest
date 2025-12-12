using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AmadeusWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class ChangeAirlinesIdentification2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Identification",
                table: "Airlines",
                newName: "ExternalIdentification");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ExternalIdentification",
                table: "Airlines",
                newName: "Identification");
        }
    }
}
