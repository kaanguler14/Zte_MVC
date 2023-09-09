using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZtProject.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddForeignKeyToDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Clients_ClientId",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "AccountHolder",
                table: "Accounts");

            migrationBuilder.AddColumn<long>(
                name: "limit",
                table: "Card",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ClosingDate",
                table: "Accounts",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "ClientId",
                table: "Accounts",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "City", "MailAddress", "Name", "Number", "Password", "PostalCode", "State", "StreetAdress", "Surname" },
                values: new object[] { "19722290612", "Bolu", "kaangulergs@gmail.com", "Kaan", "6074", "password", "14100", "Center", "Çıkınlar", "Güler" });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "AccountBalance", "AccountStatus", "AccountType", "ClientId", "ClosingDate", "IBAN", "OpeningDate" },
                values: new object[] { 1, 0.0, "Passive", "MMA", "19722290612", null, "TR1477895786321484635789631", new DateTime(2023, 9, 9, 14, 47, 24, 320, DateTimeKind.Local).AddTicks(5218) });

            migrationBuilder.InsertData(
                table: "Card",
                columns: new[] { "Id", "BankClientId", "Name", "limit", "number" },
                values: new object[] { 1, "19722290612", "Bankkart", 10000L, "8975050006755148" });

            migrationBuilder.InsertData(
                table: "CardHistory",
                columns: new[] { "Id", "Amount", "CardId", "Date", "PlaceName", "Type" },
                values: new object[] { 1, 145L, 1, new DateTime(2023, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yemek Sepeti", "Food" });

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Clients_ClientId",
                table: "Accounts",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Clients_ClientId",
                table: "Accounts");

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CardHistory",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Card",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: "19722290612");

            migrationBuilder.DropColumn(
                name: "limit",
                table: "Card");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ClosingDate",
                table: "Accounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ClientId",
                table: "Accounts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AccountHolder",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Clients_ClientId",
                table: "Accounts",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
