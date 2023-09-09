using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZtProject.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addNewDataToCardTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Clients_ClientId",
                table: "Accounts");

            migrationBuilder.AlterColumn<string>(
                name: "ClientId",
                table: "Accounts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                column: "OpeningDate",
                value: new DateTime(2023, 9, 9, 22, 26, 1, 422, DateTimeKind.Local).AddTicks(3056));

            migrationBuilder.InsertData(
                table: "Card",
                columns: new[] { "Id", "BankClientId", "Name", "limit", "number" },
                values: new object[] { 2, "19722290612", "Bankkart", 10000L, "7355051246755148" });

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: "19722290612",
                column: "Number",
                value: "3684");

            migrationBuilder.InsertData(
                table: "CardHistory",
                columns: new[] { "Id", "Amount", "CardId", "Date", "PlaceName", "Type" },
                values: new object[] { 2, 200L, 2, new DateTime(2023, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Migros ", "Market" });

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Clients_ClientId",
                table: "Accounts",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Clients_ClientId",
                table: "Accounts");

            migrationBuilder.DeleteData(
                table: "CardHistory",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Card",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<string>(
                name: "ClientId",
                table: "Accounts",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                column: "OpeningDate",
                value: new DateTime(2023, 9, 9, 14, 47, 24, 320, DateTimeKind.Local).AddTicks(5218));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: "19722290612",
                column: "Number",
                value: "6074");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Clients_ClientId",
                table: "Accounts",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id");
        }
    }
}
