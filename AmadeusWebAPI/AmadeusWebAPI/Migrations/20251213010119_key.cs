using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AmadeusWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class key : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9211887d-a15b-423f-a093-ea04d748c757", null, "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "33ed2096-c680-4948-9d57-645aa652eb31", 0, "f60901dc-6ce3-41f5-a23b-2d11746f8b09", "admin@AS.com", true, false, null, "ADMIN@AS.COM", "ADMIN@AS.COM", "AQAAAAIAAYagAAAAED7IaXXxQI5XAUFA1FjRcj8yIbcb2aojJb1GtJgKubseshRiLYBZshAJst78ErM6Kw==", null, false, "", false, "admin@as.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "9211887d-a15b-423f-a093-ea04d748c757", "33ed2096-c680-4948-9d57-645aa652eb31" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "9211887d-a15b-423f-a093-ea04d748c757", "33ed2096-c680-4948-9d57-645aa652eb31" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9211887d-a15b-423f-a093-ea04d748c757");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "33ed2096-c680-4948-9d57-645aa652eb31");

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
    }
}
