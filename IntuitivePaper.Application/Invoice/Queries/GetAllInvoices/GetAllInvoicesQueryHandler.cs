using AutoMapper;
using IntuitivePaper.Application.Invoice.Dtos;
using IntuitivePaper.Application.User;
using IntuitivePaper.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntuitivePaper.Application.Invoice.Queries.GetAllInvoices
{
    internal class GetAllInvoicesQueryHandler : IRequestHandler<GetAllInvoicesQuery, IEnumerable<InvoiceDto>>
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IMapper _mapper;
        private readonly IUserContext _userContext;

        public GetAllInvoicesQueryHandler(IInvoiceRepository invoiceRepository, IMapper mapper, IUserContext userContext)
        {
            _invoiceRepository = invoiceRepository;
            _mapper = mapper;
            _userContext = userContext;
        }
        public async Task<IEnumerable<InvoiceDto>> Handle(GetAllInvoicesQuery request, CancellationToken cancellationToken)
        {
            var invoices = await _invoiceRepository.GetAll();

            var user = _userContext.GetCurrentUser();
            var invoicesWithAccess = invoices.Where(x => user != null && x.CreatedById == user.Id);

            var dtos = _mapper.Map<IEnumerable<InvoiceDto>>(invoicesWithAccess);

            return dtos;

        }
    }
}
