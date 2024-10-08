using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpankBank1.Migrations
{
    /// <inheritdoc />
    public partial class Logindatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "BankAccounts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "BankAccounts");
        }
    }
}
