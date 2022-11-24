using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ATMBankDataLayer.Migrations
{
    public partial class addDefaultCurrencSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "CurrencyName", "Deleted", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("2627f7e3-b14c-4fa2-a342-2dc4b765f32f"), new DateTime(2022, 11, 23, 23, 4, 40, 590, DateTimeKind.Utc).AddTicks(5748), "Default", "TRY", false, null, "Default" },
                    { new Guid("71196b7a-a648-4e9f-bc51-c4235fb44696"), new DateTime(2022, 11, 23, 23, 4, 40, 590, DateTimeKind.Utc).AddTicks(5740), "Default", "EUR", false, null, "Default" },
                    { new Guid("d65f4d92-a79b-4a52-a05a-a4b96f72e7e1"), new DateTime(2022, 11, 23, 23, 4, 40, 590, DateTimeKind.Utc).AddTicks(5727), "Default", "USD", false, null, "Default" }
                });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("120276a7-bcb7-4f5d-965a-88df78d06d3b"),
                column: "CreatedAt",
                value: new DateTime(2022, 11, 23, 23, 4, 40, 590, DateTimeKind.Utc).AddTicks(5605));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("2627f7e3-b14c-4fa2-a342-2dc4b765f32f"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("71196b7a-a648-4e9f-bc51-c4235fb44696"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("d65f4d92-a79b-4a52-a05a-a4b96f72e7e1"));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("120276a7-bcb7-4f5d-965a-88df78d06d3b"),
                column: "CreatedAt",
                value: new DateTime(2022, 11, 22, 23, 47, 14, 461, DateTimeKind.Utc).AddTicks(3056));
        }
    }
}
