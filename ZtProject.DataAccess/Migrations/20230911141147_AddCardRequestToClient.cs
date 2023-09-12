using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZtProject.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddCardRequestToClient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "CardRequest",
                table: "Clients",
                type: "bit",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                column: "OpeningDate",
                value: new DateTime(2023, 9, 11, 17, 11, 47, 533, DateTimeKind.Local).AddTicks(7889));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 19722290612L,
                columns: new[] { "CardRequest", "Number" },
                values: new object[] { false, "9487" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CardRequest",
                table: "Clients");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                column: "OpeningDate",
                value: new DateTime(2023, 9, 11, 15, 16, 57, 616, DateTimeKind.Local).AddTicks(5676));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 19722290612L,
                column: "Number",
                value: "7793");
        }
    }
}
