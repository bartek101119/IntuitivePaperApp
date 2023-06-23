using IntuitivePaper.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntuitivePaper.Domain.Interfaces
{
    public interface IInvoiceItemRepository
    {
        Task Create(InvoiceItem item);
        Task<IEnumerable<InvoiceItem>> GetAllById(long id);
        Task<InvoiceItem?> GetById(long id);
        Task Delete(long id);
    }
}
