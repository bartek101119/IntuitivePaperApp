using IntuitivePaper.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace IntuitivePaper.Infrastructure.SeederService
{
    public class InvoiceSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var invoice1 = new Invoice
            {
                Id = 1,
                Number = "10",
                Date = DateTime.Now,
                SellerName = "Sprzedawca 1",
                SellerAddress = "Adres 1",
                SellerTaxId = "1234567890",
                BuyerName = "Nabywca 1",
                BuyerAddress = "Adres 2",
                BuyerTaxId = "0987654321",
                TotalNetAmount = 1000,
                TotalTaxAmount = 230,
                TotalGrossAmount = 1230
            };

            var invoiceItem1 = new InvoiceItem
            {
                Id = 1,
                Description = "Produkt 1",
                Quantity = 5,
                UnitPrice = 200,
                NetAmount = 1000,
                TaxRate = 23,
                TaxAmount = 230,
                GrossAmount = 1230,
                InvoiceId = invoice1.Id, // Ustaw wartość klucza obcego
            };

            modelBuilder.Entity<Invoice>().HasData(invoice1);
            modelBuilder.Entity<InvoiceItem>().HasData(invoiceItem1);
        }
    }
}