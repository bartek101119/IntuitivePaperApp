using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IntuitivePaper.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class seederInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "BuyerAddress", "BuyerName", "BuyerTaxId", "Date", "Number", "SellerAddress", "SellerName", "SellerTaxId", "TotalGrossAmount", "TotalNetAmount", "TotalTaxAmount" },
                values: new object[] { 1L, "Adres 2", "Nabywca 1", "0987654321", new DateTime(2023, 6, 21, 14, 36, 20, 951, DateTimeKind.Local).AddTicks(4600), "10", "Adres 1", "Sprzedawca 1", "1234567890", 1230m, 1000m, 230m });

            migrationBuilder.InsertData(
                table: "InvoiceItems",
                columns: new[] { "Id", "Description", "GrossAmount", "InvoiceId", "NetAmount", "Quantity", "TaxAmount", "TaxRate", "UnitPrice" },
                values: new object[] { 1L, "Produkt 1", 1230m, 1L, 1000m, 5, 230m, 23m, 200m });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "InvoiceItems",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 1L);
        }
    }
}
