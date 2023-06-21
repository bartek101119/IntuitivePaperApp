using IntuitivePaper.Domain.Entities;
using IntuitivePaper.Domain.Interfaces;
using IntuitivePaper.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntuitivePaper.Infrastructure.Repository
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly IntuitivePaperContext _context;

        public InvoiceRepository(IntuitivePaperContext context)
        {
            _context = context;
        }
        public async Task Create(Invoice invoice)
        {
            _context.Invoices.Add(invoice);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Invoice>> GetAll() => await _context.Invoices.ToListAsync();

        public async Task<Invoice> GetById(long id) => await _context.Invoices.FindAsync(id);
    }
}
