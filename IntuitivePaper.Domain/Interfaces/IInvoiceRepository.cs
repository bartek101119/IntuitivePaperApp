using IntuitivePaper.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntuitivePaper.Domain.Interfaces
{
    public interface IInvoiceRepository
    {
        Task Create(Invoice invoice);
        Task<Invoice?> GetById(long id);
        Task<IEnumerable<Invoice>> GetAll();
        Task Save();
    }
}
