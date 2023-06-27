using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IntuitivePaper.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class PlaceOfIssueColumnAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PlaceOfIssue",
                table: "Invoices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlaceOfIssue",
                table: "Invoices");
        }
    }
}
