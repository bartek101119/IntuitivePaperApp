using IntuitivePaper.Application.Invoice.Dtos;
using IntuitivePaper.Domain.Entities;

namespace IntuitivePaper.MVC.Models
{
    public class InvoiceViewModel
    {
        public List<InvoiceDto>? Invoices { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public string? SearchString { get; set; }
    }
}
