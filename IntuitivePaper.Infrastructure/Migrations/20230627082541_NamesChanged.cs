using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IntuitivePaper.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NamesChanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PKOB",
                table: "InvoiceItems");

            migrationBuilder.RenameColumn(
                name: "PKWiU",
                table: "InvoiceItems",
                newName: "PKWiUorPKOB");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PKWiUorPKOB",
                table: "InvoiceItems",
                newName: "PKWiU");

            migrationBuilder.AddColumn<string>(
                name: "PKOB",
                table: "InvoiceItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
