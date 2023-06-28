using IntuitivePaper.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntuitivePaper.Application.Invoice.Commands.RemoveInvoice
{
    public class RemoveInvoiceCommandHandler : IRequestHandler<RemoveInvoiceCommand>
    {
        private readonly IInvoiceRepository _invoiceRepository;

        public RemoveInvoiceCommandHandler(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }
        public async Task<Unit> Handle(RemoveInvoiceCommand request, CancellationToken cancellationToken)
        {
            var invoice = await _invoiceRepository.GetById(request.InvoiceId);

            if (invoice != null)
            {
                await _invoiceRepository.DeleteById(invoice);

                await _invoiceRepository.Save();
            }

            return Unit.Value;
        }
    }
}
