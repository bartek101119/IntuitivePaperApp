using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IntuitivePaper.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class PeselRemoved : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BuyerPESEL",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "SellerPESEL",
                table: "Invoices");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BuyerPESEL",
                table: "Invoices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SellerPESEL",
                table: "Invoices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
