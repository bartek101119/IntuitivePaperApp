using AutoMapper;
using IntuitivePaper.Application.User;
using IntuitivePaper.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntuitivePaper.Application.Invoice.Commands.CreateInvoice
{
    public class CreateInvoiceCommandHandler : IRequestHandler<CreateInvoiceCommand>
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IMapper _mapper;
        private readonly IUserContext _userContext;

        public CreateInvoiceCommandHandler(IInvoiceRepository invoiceRepository, IMapper mapper, IUserContext userContext)
        {
            _invoiceRepository = invoiceRepository;
            _mapper = mapper;
            _userContext = userContext;
        }
        public async Task<Unit> Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
        {
            var invoice = _mapper.Map<Domain.Entities.Invoice>(request);

            invoice.NumberAsWords = "metoda do stworzenia";

            invoice.DateCreatedUtc = DateTime.UtcNow;

            invoice.CreatedById = _userContext.GetCurrentUser().Id;

            await _invoiceRepository.Create(invoice);

            return Unit.Value;
        }
    }
}
