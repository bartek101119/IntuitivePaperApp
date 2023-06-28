using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntuitivePaper.Application.Invoice.Commands.RemoveInvoice
{
    public class RemoveInvoiceCommand : IRequest
    {
        public long InvoiceId { get; set; }

        public RemoveInvoiceCommand(long invoiceId)
        {
            InvoiceId = invoiceId;
        }
    }
}
