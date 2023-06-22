using AutoMapper;
using IntuitivePaper.Application.Invoice.Dtos;
using IntuitivePaper.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntuitivePaper.Application.Invoice.Queries.GetByIdInvoice
{
    public class GetByIdInvoiceQueryHandler : IRequestHandler<GetByIdInvoiceQuery, InvoiceDto>
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IMapper _mapper;

        public GetByIdInvoiceQueryHandler(IInvoiceRepository invoiceRepository, IMapper mapper)
        {
            _invoiceRepository = invoiceRepository;
            _mapper = mapper;
        }
        public async Task<InvoiceDto> Handle(GetByIdInvoiceQuery request, CancellationToken cancellationToken)
        {
            var invoice = await _invoiceRepository.GetById(request.Id);

            var invoiceDto = _mapper.Map<InvoiceDto>(invoice);

            return invoiceDto;
        }
    }
}
