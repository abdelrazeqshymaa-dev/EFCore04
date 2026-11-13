using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EFCore04.Migrations
{
    /// <inheritdoc />
    public partial class SeedBankData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "AccountNumber", "AccountType", "BranchId", "CurrentBalance", "OpeningDate" },
                values: new object[,]
                {
                    { "12356", 1, 1, 15000m, new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "12357", 2, 1, 25000m, new DateTime(2025, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "12358", 1, 2, 10000m, new DateTime(2025, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "12359", 3, 2, 100000m, new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "12360", 2, 1, 5000m, new DateTime(2025, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "12361", 1, 2, 3000m, new DateTime(2025, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "CustomerType", "DateOfBirth", "Email", "FullName", "NationalId", "PhoneNumber" },
                values: new object[,]
                {
                    { 2, "Giza", 1, new DateTime(1995, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "sara@gmail.com", "Sara Ali", "29502021234567", "01023456789" },
                    { 3, "Alexandria", 1, new DateTime(1988, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "omar@gmail.com", "Omar Hassan", "28803031234567", "01034567890" },
                    { 4, "Cairo", 2, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "abc@company.com", "ABC Company", "12345678901234", "01045678901" },
                    { 5, "Giza", 1, new DateTime(1998, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "mona2@gmail.com", "Mona Samir", "29805051234567", "01056789012" }
                });

            migrationBuilder.InsertData(
                table: "CustomerAccounts",
                columns: new[] { "AccountNumber", "CustomerId", "AccountStatus", "OwnershipStartDate", "OwnershipType" },
                values: new object[,]
                {
                    { "12356", 1, 1, new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "12356", 2, 1, new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "12357", 2, 1, new DateTime(2025, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "12356", 3, 1, new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "12358", 3, 1, new DateTime(2025, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "12359", 4, 1, new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "12360", 5, 2, new DateTime(2025, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "AccountNumber",
                keyValue: "12361");

            migrationBuilder.DeleteData(
                table: "CustomerAccounts",
                keyColumns: new[] { "AccountNumber", "CustomerId" },
                keyValues: new object[] { "12356", 1 });

            migrationBuilder.DeleteData(
                table: "CustomerAccounts",
                keyColumns: new[] { "AccountNumber", "CustomerId" },
                keyValues: new object[] { "12356", 2 });

            migrationBuilder.DeleteData(
                table: "CustomerAccounts",
                keyColumns: new[] { "AccountNumber", "CustomerId" },
                keyValues: new object[] { "12357", 2 });

            migrationBuilder.DeleteData(
                table: "CustomerAccounts",
                keyColumns: new[] { "AccountNumber", "CustomerId" },
                keyValues: new object[] { "12356", 3 });

            migrationBuilder.DeleteData(
                table: "CustomerAccounts",
                keyColumns: new[] { "AccountNumber", "CustomerId" },
                keyValues: new object[] { "12358", 3 });

            migrationBuilder.DeleteData(
                table: "CustomerAccounts",
                keyColumns: new[] { "AccountNumber", "CustomerId" },
                keyValues: new object[] { "12359", 4 });

            migrationBuilder.DeleteData(
                table: "CustomerAccounts",
                keyColumns: new[] { "AccountNumber", "CustomerId" },
                keyValues: new object[] { "12360", 5 });

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "AccountNumber",
                keyValue: "12356");

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "AccountNumber",
                keyValue: "12357");

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "AccountNumber",
                keyValue: "12358");

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "AccountNumber",
                keyValue: "12359");

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "AccountNumber",
                keyValue: "12360");

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
