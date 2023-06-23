using IntuitivePaper.Application.InvoiceItem.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntuitivePaper.Application.InvoiceItem.Commands.CreateInvoiceItem
{
    public class CreateInvoiceItemCommand : InvoiceItemDto, IRequest
    {
        public long InvoiceId { get; set; }
    }
}
