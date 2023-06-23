using IntuitivePaper.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntuitivePaper.Application.InvoiceItem.Commands.RemoveInvoiceItem
{
    public class RemoveInvoiceItemCommandHandler : IRequestHandler<RemoveInvoiceItemCommand>
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IInvoiceItemRepository _invoiceItemRepository;

        public RemoveInvoiceItemCommandHandler(IInvoiceRepository invoiceRepository, IInvoiceItemRepository invoiceItemRepository)
        {
            _invoiceRepository = invoiceRepository;
            _invoiceItemRepository = invoiceItemRepository;
        }
        public async Task<Unit> Handle(RemoveInvoiceItemCommand request, CancellationToken cancellationToken)
        {
            var invoice = await _invoiceRepository.GetById(request.InvoiceId);

            var invoiceItem = await _invoiceItemRepository.GetById(request.InvoiceItemId);

            // Usuń element faktury
            await _invoiceItemRepository.Delete(invoiceItem.Id);

            return Unit.Value;
        }
    }
}
