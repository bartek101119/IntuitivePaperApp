using AutoMapper;
using IntuitivePaper.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntuitivePaper.Application.InvoiceItem.Commands.CreateInvoiceItem
{
    public class CreateInvoiceItemCommandHandler : IRequestHandler<CreateInvoiceItemCommand>
    {
        private readonly IMapper _mapper;
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IInvoiceItemRepository _invoiceItemRepository;

        public CreateInvoiceItemCommandHandler(IMapper mapper, IInvoiceRepository invoiceRepository, IInvoiceItemRepository invoiceItemRepository)
        {
            _mapper = mapper;
            _invoiceRepository = invoiceRepository;
            _invoiceItemRepository = invoiceItemRepository;
        }
        public async Task<Unit> Handle(CreateInvoiceItemCommand request, CancellationToken cancellationToken)
        {
            var invoice = await _invoiceRepository.GetById(request.InvoiceId);

            var invoiceItem = new Domain.Entities.InvoiceItem()
            {
                Description = request.Description,
                Quantity = request.Quantity,
                UnitPrice = request.UnitPrice,
                NetAmount = request.NetAmount,
                TaxRate = request.TaxRate,
                TaxAmount = request.TaxAmount,
                GrossAmount = request.GrossAmount,
                InvoiceId = invoice.Id
            };

            await _invoiceItemRepository.Create(invoiceItem);

            return Unit.Value;
        }
    }
}
