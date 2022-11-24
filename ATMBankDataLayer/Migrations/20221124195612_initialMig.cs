using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ATMBankDataLayer.Migrations
{
    public partial class initialMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CurrencyName = table.Column<string>(type: "text", nullable: false),
                    AccountType = table.Column<int>(type: "integer", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    UpdatedBy = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Surname = table.Column<string>(type: "text", nullable: false),
                    Pin = table.Column<long>(type: "bigint", nullable: false),
                    IdentityNumber = table.Column<long>(type: "bigint", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    UpdatedBy = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AccountHistories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TransactionType = table.Column<string>(type: "text", nullable: false),
                    CustomersId = table.Column<Guid>(type: "uuid", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    UpdatedBy = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountHistories_Customers_CustomersId",
                        column: x => x.CustomersId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BalanceAccounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CurrentBalance = table.Column<decimal>(type: "numeric", nullable: false),
                    CurrenciesId = table.Column<Guid>(type: "uuid", nullable: false),
                    CustomersId = table.Column<Guid>(type: "uuid", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    UpdatedBy = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BalanceAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BalanceAccounts_Currencies_CurrenciesId",
                        column: x => x.CurrenciesId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BalanceAccounts_Customers_CustomersId",
                        column: x => x.CustomersId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "Id", "AccountType", "CreatedAt", "CreatedBy", "CurrencyName", "Deleted", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("2627f7e3-b14c-4fa2-a342-2dc4b765f32f"), 1, new DateTime(2022, 11, 24, 22, 56, 12, 706, DateTimeKind.Local).AddTicks(7667), "Default", "TRY", false, new DateTime(2022, 11, 24, 22, 56, 12, 706, DateTimeKind.Local).AddTicks(7668), "Default" },
                    { new Guid("71196b7a-a648-4e9f-bc51-c4235fb44696"), 2, new DateTime(2022, 11, 24, 22, 56, 12, 706, DateTimeKind.Local).AddTicks(7658), "Default", "EUR", false, new DateTime(2022, 11, 24, 22, 56, 12, 706, DateTimeKind.Local).AddTicks(7659), "Default" },
                    { new Guid("d65f4d92-a79b-4a52-a05a-a4b96f72e7e1"), 3, new DateTime(2022, 11, 24, 22, 56, 12, 706, DateTimeKind.Local).AddTicks(7646), "Default", "USD", false, new DateTime(2022, 11, 24, 22, 56, 12, 706, DateTimeKind.Local).AddTicks(7646), "Default" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Deleted", "IdentityNumber", "Name", "Pin", "Surname", "UpdatedAt", "UpdatedBy" },
                values: new object[] { new Guid("120276a7-bcb7-4f5d-965a-88df78d06d3b"), new DateTime(2022, 11, 24, 22, 56, 12, 706, DateTimeKind.Local).AddTicks(7531), "Default", false, 111222333444L, "Numan", 1234L, "Kul", new DateTime(2022, 11, 24, 22, 56, 12, 706, DateTimeKind.Local).AddTicks(7542), "Default" });

            migrationBuilder.InsertData(
                table: "BalanceAccounts",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "CurrenciesId", "CurrentBalance", "CustomersId", "Deleted", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("6f53285b-002f-4411-ad9c-b26d0a6b0ca5"), new DateTime(2022, 11, 24, 22, 56, 12, 706, DateTimeKind.Local).AddTicks(7679), "Default", new Guid("2627f7e3-b14c-4fa2-a342-2dc4b765f32f"), 1500m, new Guid("120276a7-bcb7-4f5d-965a-88df78d06d3b"), false, new DateTime(2022, 11, 24, 22, 56, 12, 706, DateTimeKind.Local).AddTicks(7680), "Default" },
                    { new Guid("7b6e9787-7218-4c41-8e46-468f316db478"), new DateTime(2022, 11, 24, 22, 56, 12, 706, DateTimeKind.Local).AddTicks(7695), "Default", new Guid("d65f4d92-a79b-4a52-a05a-a4b96f72e7e1"), 100m, new Guid("120276a7-bcb7-4f5d-965a-88df78d06d3b"), false, new DateTime(2022, 11, 24, 22, 56, 12, 706, DateTimeKind.Local).AddTicks(7695), "Default" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountHistories_CustomersId",
                table: "AccountHistories",
                column: "CustomersId");

            migrationBuilder.CreateIndex(
                name: "IX_BalanceAccounts_CurrenciesId",
                table: "BalanceAccounts",
                column: "CurrenciesId");

            migrationBuilder.CreateIndex(
                name: "IX_BalanceAccounts_CustomersId",
                table: "BalanceAccounts",
                column: "CustomersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountHistories");

            migrationBuilder.DropTable(
                name: "BalanceAccounts");

            migrationBuilder.DropTable(
                name: "Currencies");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
