using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntuitivePaper.Application.InvoiceItem.Dtos
{
    public class InvoiceItemDto
    {
        public long Id { get; set; }
        public string Description { get; set; } = default!; // Opis towaru lub usługi
        public int Quantity { get; set; } // Ilość
        public decimal UnitPrice { get; set; } // Cena jednostkowa netto
        public decimal NetAmount { get; set; } // Wartość netto
        public decimal TaxRate { get; set; } // Stawka podatku VAT
        public decimal TaxAmount { get; set; } // Kwota podatku VAT
        public decimal GrossAmount { get; set; } // Wartość brutto
        public string PKWiUorPKOB { get; set; } = default!; // PKWiU
        public string UnitMeasure { get; set; } = default!; // Jednostka miary
    }
}
