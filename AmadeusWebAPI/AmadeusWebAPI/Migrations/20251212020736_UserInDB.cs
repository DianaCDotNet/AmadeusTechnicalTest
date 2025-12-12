using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AmadeusWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class UserInDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a004a9e9-e038-4e18-85bf-1e78dd2c719f", null, "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b394f7a6-e835-4310-8527-e4849d40294c", 0, "042a47c9-d1bf-4474-9d76-7e65c5b5acfc", "admin@AS.com", true, false, null, "ADMIN@AS.COM", "ADMIN@AS.COM", "AQAAAAIAAYagAAAAELAeIw6PhSrI1VfANegACpGal/+wU3QSn285B+UgCFGv0zGV0RXHN2CW8ARr+JX9uQ==", null, false, "", false, "admin@as.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "a004a9e9-e038-4e18-85bf-1e78dd2c719f", "b394f7a6-e835-4310-8527-e4849d40294c" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a004a9e9-e038-4e18-85bf-1e78dd2c719f", "b394f7a6-e835-4310-8527-e4849d40294c" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a004a9e9-e038-4e18-85bf-1e78dd2c719f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b394f7a6-e835-4310-8527-e4849d40294c");
        }
    }
}
