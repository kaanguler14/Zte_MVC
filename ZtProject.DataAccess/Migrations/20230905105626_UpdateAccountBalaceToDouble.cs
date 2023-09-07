using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZtProject.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAccountBalaceToDouble : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "AccountBalance",
                table: "Accounts",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "AccountBalance",
                table: "Accounts",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }
    }
}
