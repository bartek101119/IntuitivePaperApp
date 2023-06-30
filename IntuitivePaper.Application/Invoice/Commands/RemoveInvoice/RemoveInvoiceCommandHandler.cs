using IntuitivePaper.Application.User;
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
        private readonly IUserContext _userContext;

        public RemoveInvoiceCommandHandler(IInvoiceRepository invoiceRepository, IUserContext userContext)
        {
            _invoiceRepository = invoiceRepository;
            _userContext = userContext;
        }
        public async Task<Unit> Handle(RemoveInvoiceCommand request, CancellationToken cancellationToken)
        {
            var invoice = await _invoiceRepository.GetById(request.InvoiceId);

            if (invoice != null)
            {
                var user = _userContext.GetCurrentUser();
                var hasAccess = user != null && invoice.CreatedById == user.Id;
                if (!hasAccess)
                {
                    return Unit.Value;
                }

                await _invoiceRepository.DeleteById(invoice);

                await _invoiceRepository.Save();
            }

            return Unit.Value;
        }
    }
}
