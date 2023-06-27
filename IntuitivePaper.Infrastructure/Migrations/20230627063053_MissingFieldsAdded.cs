using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IntuitivePaper.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MissingFieldsAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "InvoiceItems",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.AddColumn<int>(
                name: "AccountNumber",
                table: "Invoices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Bank",
                table: "Invoices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BuyerPESEL",
                table: "Invoices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NumberAsWords",
                table: "Invoices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "PaymentDate",
                table: "Invoices",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "PaymentMethod",
                table: "Invoices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "SaleDate",
                table: "Invoices",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "SellerPESEL",
                table: "Invoices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PKOB",
                table: "InvoiceItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PKWiU",
                table: "InvoiceItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UnitMeasure",
                table: "InvoiceItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountNumber",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "Bank",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "BuyerPESEL",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "NumberAsWords",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "PaymentDate",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "PaymentMethod",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "SaleDate",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "SellerPESEL",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "PKOB",
                table: "InvoiceItems");

            migrationBuilder.DropColumn(
                name: "PKWiU",
                table: "InvoiceItems");

            migrationBuilder.DropColumn(
                name: "UnitMeasure",
                table: "InvoiceItems");

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "BuyerAddress", "BuyerName", "BuyerTaxId", "Date", "Number", "SellerAddress", "SellerName", "SellerTaxId", "TotalGrossAmount", "TotalNetAmount", "TotalTaxAmount" },
                values: new object[] { 1L, "Adres 2", "Nabywca 1", "0987654321", new DateTime(2023, 6, 21, 14, 36, 20, 951, DateTimeKind.Local).AddTicks(4600), "10", "Adres 1", "Sprzedawca 1", "1234567890", 1230m, 1000m, 230m });

            migrationBuilder.InsertData(
                table: "InvoiceItems",
                columns: new[] { "Id", "Description", "GrossAmount", "InvoiceId", "NetAmount", "Quantity", "TaxAmount", "TaxRate", "UnitPrice" },
                values: new object[] { 1L, "Produkt 1", 1230m, 1L, 1000m, 5, 230m, 23m, 200m });
        }
    }
}
