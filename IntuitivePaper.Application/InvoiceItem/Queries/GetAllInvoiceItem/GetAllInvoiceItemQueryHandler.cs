using AutoMapper;
using IntuitivePaper.Application.InvoiceItem.Dtos;
using IntuitivePaper.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntuitivePaper.Application.InvoiceItem.Queries.GetAllInvoiceItem
{
    public class GetAllInvoiceItemQueryHandler : IRequestHandler<GetAllInvoiceItemQuery, IEnumerable<InvoiceItemDto>>
    {
        private readonly IInvoiceItemRepository _invoiceItemRepository;
        private readonly IMapper _mapper;

        public GetAllInvoiceItemQueryHandler(IInvoiceItemRepository invoiceItemRepository, IMapper mapper)
        {
            _invoiceItemRepository = invoiceItemRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<InvoiceItemDto>> Handle(GetAllInvoiceItemQuery request, CancellationToken cancellationToken)
        {
            var invoiceItem = await _invoiceItemRepository.GetAllById(request.InvoiceId);

            var dtos = _mapper.Map<IEnumerable<InvoiceItemDto>>(invoiceItem);

            return dtos;
        }
    }
}
