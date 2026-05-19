using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PJATK_APBD_Cw7_s34260.Migrations
{
    /// <inheritdoc />
    public partial class seed2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ComponentManufacturers",
                columns: new[] { "Id", "Abbreviation", "FoundationDate", "FullName" },
                values: new object[,]
                {
                    { 2, "pongos2", new DateTime(2024, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "pongos pongos2" },
                    { 3, "pongos3", new DateTime(2024, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "pongos pongos3" }
                });

            migrationBuilder.InsertData(
                table: "ComponentTypes",
                columns: new[] { "Id", "Abbreviation", "Name" },
                values: new object[,]
                {
                    { 2, "plingos2", "Plingos pangos2" },
                    { 3, "plingos3", "Plingos pangos3" }
                });

            migrationBuilder.InsertData(
                table: "PCs",
                columns: new[] { "Id", "CreatedAt", "Name", "Stock", "Warranty", "Weight" },
                values: new object[,]
                {
                    { 2, new DateTime(2024, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 4, 2, 0.5f },
                    { 3, new DateTime(2024, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 4, 2, 0.5f }
                });

            migrationBuilder.InsertData(
                table: "Components",
                columns: new[] { "Code", "ComponentManufacturersId", "ComponentTypesId", "Description", "Name" },
                values: new object[,]
                {
                    { "1234567892", 2, 2, "panglor ultimax2", "panglor2" },
                    { "1234567893", 3, 3, "panglor ultimax3", "panglor3" }
                });

            migrationBuilder.InsertData(
                table: "PCComponents",
                columns: new[] { "ComponentCode", "PCId", "Amount" },
                values: new object[,]
                {
                    { "1234567892", 2, 50 },
                    { "1234567893", 3, 50 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PCComponents",
                keyColumns: new[] { "ComponentCode", "PCId" },
                keyValues: new object[] { "1234567892", 2 });

            migrationBuilder.DeleteData(
                table: "PCComponents",
                keyColumns: new[] { "ComponentCode", "PCId" },
                keyValues: new object[] { "1234567893", 3 });

            migrationBuilder.DeleteData(
                table: "Components",
                keyColumn: "Code",
                keyValue: "1234567892");

            migrationBuilder.DeleteData(
                table: "Components",
                keyColumn: "Code",
                keyValue: "1234567893");

            migrationBuilder.DeleteData(
                table: "PCs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PCs",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ComponentManufacturers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ComponentManufacturers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ComponentTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ComponentTypes",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
