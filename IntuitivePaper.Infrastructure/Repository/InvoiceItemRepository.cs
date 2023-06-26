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
    public class InvoiceItemRepository : IInvoiceItemRepository
    {
        private readonly IntuitivePaperContext _context;

        public InvoiceItemRepository(IntuitivePaperContext context)
        {
            _context = context;
        }
        public async Task Create(InvoiceItem item)
        {
            _context.InvoiceItems.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(long id)
        {
            var item = await _context.InvoiceItems.FirstOrDefaultAsync(x => x.Id == id);

            if (item != null)
            {
                _context.InvoiceItems.Remove(item);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<InvoiceItem>> GetAllById(long id)
            => await _context.InvoiceItems
            .Where(x => x.Invoice.Id == id)
            .ToListAsync();

        public async Task<InvoiceItem?> GetById(long id)
            => await _context.InvoiceItems
            .FirstOrDefaultAsync(x => x.Id == id);

    }
}
