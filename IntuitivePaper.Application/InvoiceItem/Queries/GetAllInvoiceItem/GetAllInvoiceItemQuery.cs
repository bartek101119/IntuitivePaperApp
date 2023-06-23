using IntuitivePaper.Application.InvoiceItem.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntuitivePaper.Application.InvoiceItem.Queries.GetAllInvoiceItem
{
    public class GetAllInvoiceItemQuery : IRequest<IEnumerable<InvoiceItemDto>>
    {
        public long InvoiceId { get; set; }
        public GetAllInvoiceItemQuery(long invoiceId)
        {
            InvoiceId = invoiceId;
        }
    }
}
