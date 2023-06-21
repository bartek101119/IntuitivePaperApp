﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntuitivePaper.Domain.Entities
{
    public class Invoice
    {
        public long Id { get; set; }
        public string Number { get; set; } = default!; // Numer faktury
        public DateTime Date { get; set; } // Data wystawienia
        public string SellerName { get; set; } = default!; // Nazwa sprzedawcy
        public string SellerAddress { get; set; } = default!; // Adres sprzedawcy
        public string SellerTaxId { get; set; } = default!; // NIP sprzedawcy
        public string BuyerName { get; set; } = default!; // Nazwa nabywcy
        public string BuyerAddress { get; set; } = default!;// Adres nabywcy
        public string BuyerTaxId { get; set; } = default!; // NIP nabywcy
        public List<InvoiceItem> Items { get; set; } = new(); // Pozycje na fakturze
        public decimal TotalNetAmount { get; set; } // Łączna kwota netto
        public decimal TotalTaxAmount { get; set; } // Łączna kwota podatku
        public decimal TotalGrossAmount { get; set; } // Łączna kwota brutto
    }
}