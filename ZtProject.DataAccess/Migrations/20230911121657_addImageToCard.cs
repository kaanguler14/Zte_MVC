using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZtProject.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addImageToCard : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Card",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                column: "OpeningDate",
                value: new DateTime(2023, 9, 11, 15, 16, 57, 616, DateTimeKind.Local).AddTicks(5676));

            migrationBuilder.UpdateData(
                table: "Card",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "Card",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 19722290612L,
                column: "Number",
                value: "7793");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Card");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                column: "OpeningDate",
                value: new DateTime(2023, 9, 10, 15, 15, 51, 558, DateTimeKind.Local).AddTicks(1198));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 19722290612L,
                column: "Number",
                value: "9984");
        }
    }
}
