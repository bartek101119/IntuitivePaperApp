using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntuitivePaper.Application.InvoiceItem.Commands.RemoveInvoiceItem
{
    public class RemoveInvoiceItemCommand : IRequest
    {
        public long InvoiceId { get; set; }
        public long InvoiceItemId { get; set; }
        public RemoveInvoiceItemCommand(long invoiceId, long invoiceItemId)
        {
            InvoiceId = invoiceId;
            InvoiceItemId = invoiceItemId;
        }
    }
}
