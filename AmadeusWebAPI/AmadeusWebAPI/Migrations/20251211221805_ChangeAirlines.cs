using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AmadeusWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class ChangeAirlines : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Names",
                table: "Airlines",
                newName: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Airlines",
                newName: "Names");
        }
    }
}
