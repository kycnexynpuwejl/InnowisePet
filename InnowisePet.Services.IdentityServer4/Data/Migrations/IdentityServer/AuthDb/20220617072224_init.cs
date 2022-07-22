using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InnowisePet.IdentityServer4.Data.Migrations.IdentityServer.AuthDb
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "d2f1d6e8-7372-4632-8a34-5ec108d60744");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "dc3cc7b3-4de1-4861-b9f0-02b658827e47");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6b0fbc8c-2d84-4d60-bb3a-d374a2588b3a", "aa918a39-9b10-49c1-a725-edf0b8fd34b5", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ee7b4ed0-c94a-4d6f-bfc1-6299f11ec06d", "ab2cda29-216e-48f4-8b4d-17c0d39c662e", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "6b0fbc8c-2d84-4d60-bb3a-d374a2588b3a");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "ee7b4ed0-c94a-4d6f-bfc1-6299f11ec06d");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d2f1d6e8-7372-4632-8a34-5ec108d60744", "aa185422-6b70-477f-b49e-fd289e7763d7", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "dc3cc7b3-4de1-4861-b9f0-02b658827e47", "c5906923-f9e6-4d5b-a775-0060df3c134f", "Customer", "CUSTOMER" });
        }
    }
}
