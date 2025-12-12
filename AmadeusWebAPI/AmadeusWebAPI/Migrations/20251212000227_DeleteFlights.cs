using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AmadeusWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class DeleteFlights : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Flights");

            migrationBuilder.AddColumn<string>(
                name: "AditionalInformation",
                table: "Airlines",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NuberFlightsPerDay",
                table: "Airlines",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "OriginCountry",
                table: "Airlines",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AditionalInformation",
                table: "Airlines");

            migrationBuilder.DropColumn(
                name: "NuberFlightsPerDay",
                table: "Airlines");

            migrationBuilder.DropColumn(
                name: "OriginCountry",
                table: "Airlines");

            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AirlineId = table.Column<int>(type: "int", nullable: false),
                    FlightName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Flights_Airlines_AirlineId",
                        column: x => x.AirlineId,
                        principalTable: "Airlines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Flights_AirlineId",
                table: "Flights",
                column: "AirlineId");
        }
    }
}
