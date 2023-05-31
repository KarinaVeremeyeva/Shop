using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Shop.IdentityApi.Migrations
{
    /// <inheritdoc />
    public partial class AddUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "beea0094-0cde-4f04-812b-98c02f4f8e27",
                column: "ConcurrencyStamp",
                value: "14ba4d6c-f362-4d6b-a307-a60abf42050e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e1110812-5f76-4889-93a7-b4c677c2d8dd",
                column: "ConcurrencyStamp",
                value: "784323d5-4fa2-4379-aa55-58a712643348");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2288a9b4-35ee-4c13-b863-36184e701e0a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4bd63653-fb45-49fd-8779-c33d8b56aea8", "AQAAAAEAACcQAAAAEPAMRrx184ubl655gx1WSOBExeovToZSrs1JxJjR+/4FFVUOdPhd5gMxGkDjLWKOnQ==", "ffbc4efb-3a60-40b1-8fc5-5e89694dcbcb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5eb5d348-b220-4148-8f9b-570de6262aa8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "82ea35ec-3575-4a81-a22c-98c5b9e06fc9", "AQAAAAEAACcQAAAAENLJLcYrTVUCUkLDzERJTcQZjk1/n0l1lngGca6mmf22fhxuVkEJzEQNYwSBY6fNSQ==", "6b58b739-35eb-4d88-8b07-6edb7c9b7bc5" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "056096da-3246-40a7-af6f-726f5f4a74ee", 0, "9c4ffa47-6825-4a33-9187-3ce0a46c6271", "user3@gmail.com", false, false, null, "USER3@GMAIL.COM", "USER3@GMAIL.COM", "AQAAAAEAACcQAAAAEAp/a87MuORy2Se4v+NiIqk1eu5sdY5QsjYr1niFMbauX5QOh/Zs7XkF30NJgNKXyw==", null, false, "c6455dad-a194-4fe4-942d-dc6c5fb96647", false, "user3@gmail.com" },
                    { "3758bb9b-3ad6-457c-9ff5-c88f338c7d48", 0, "b727842b-bc49-4c3d-9bc9-1fc2943c8cfd", "user2@gmail.com", false, false, null, "USER2@GMAIL.COM", "USER2@GMAIL.COM", "AQAAAAEAACcQAAAAECizFLRrAC+Zc1Y8t6qGZ4/JnAl4beCPphalNwnxR6wV8uGj1WAgQgYxFBUSXX4gxw==", null, false, "3710fda3-0959-4ae6-b1c8-2ab13f696ce9", false, "user2@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "beea0094-0cde-4f04-812b-98c02f4f8e27", "056096da-3246-40a7-af6f-726f5f4a74ee" },
                    { "beea0094-0cde-4f04-812b-98c02f4f8e27", "3758bb9b-3ad6-457c-9ff5-c88f338c7d48" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "beea0094-0cde-4f04-812b-98c02f4f8e27", "056096da-3246-40a7-af6f-726f5f4a74ee" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "beea0094-0cde-4f04-812b-98c02f4f8e27", "3758bb9b-3ad6-457c-9ff5-c88f338c7d48" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "056096da-3246-40a7-af6f-726f5f4a74ee");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3758bb9b-3ad6-457c-9ff5-c88f338c7d48");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "beea0094-0cde-4f04-812b-98c02f4f8e27",
                column: "ConcurrencyStamp",
                value: "bc9923fc-49f3-445c-b577-46c3d4aa3e47");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e1110812-5f76-4889-93a7-b4c677c2d8dd",
                column: "ConcurrencyStamp",
                value: "5b85ba9e-9ed1-42bb-a1a6-d6637b8a1997");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2288a9b4-35ee-4c13-b863-36184e701e0a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ade809b4-ae27-4848-a894-5af445cb85a8", "AQAAAAEAACcQAAAAEINOtqTwVHPaciG64dDsLe6BXKL/dUgVE+6bgBsEwUTvlMdsaKc0oKHqbM9VP6sIyQ==", "8379fa8e-ef2e-42f3-998b-1c1f2ca18bf8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5eb5d348-b220-4148-8f9b-570de6262aa8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1177b78c-1a5c-4216-85d6-dc16c2680d21", "AQAAAAEAACcQAAAAEI2gv8pJtW5ulHcRBmkOTJhKNv63VWF1XrcFZ9BIrM9pigvgRIh4cosrk5gWIpZkJQ==", "58cf9b73-1c03-4086-a13c-7fdcf8b4c55e" });
        }
    }
}
