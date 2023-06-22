using IntuitivePaper.Application.Invoice.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntuitivePaper.Application.Invoice.Commands.EditInvoice
{
    public class EditInvoiceCommand : InvoiceDto, IRequest
    {
    }
}
