using AutoMapper;
using IntuitivePaper.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntuitivePaper.Application.Invoice.Commands.EditInvoice
{
    public class EditInvoiceCommandHandler : IRequestHandler<EditInvoiceCommand>
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IMapper _mapper;

        public EditInvoiceCommandHandler(IInvoiceRepository invoiceRepository, IMapper mapper)
        {
            _invoiceRepository = invoiceRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(EditInvoiceCommand request, CancellationToken cancellationToken)
        {
            var invoice = await _invoiceRepository.GetById(request.Id);

            if (invoice != null)
            {
                invoice.Number = request.Number;
                invoice.Date = request.Date;
                invoice.SellerName = request.SellerName;
                invoice.SellerAddress = request.SellerAddress;
                invoice.SellerTaxId = request.SellerTaxId;
                invoice.BuyerName = request.BuyerName;
                invoice.BuyerAddress = request.BuyerAddress;
                invoice.BuyerTaxId = request.BuyerTaxId;

                // Modyfikacje innych właściwości faktury
            }
            await _invoiceRepository.Save(); // Zapisz zmodyfikowaną fakturę w repozytorium

            return Unit.Value;
        }
    }
}
