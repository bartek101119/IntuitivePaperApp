using IntuitivePaper.Application.Invoice.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntuitivePaper.Application.Invoice.Queries.GetByIdInvoice
{
    public class GetByIdInvoiceQuery : IRequest<InvoiceDto>
    {
        public long Id { get; set; }

        public GetByIdInvoiceQuery(long id)
        {
            Id = id;
        }
    }
}
