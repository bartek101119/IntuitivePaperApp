using AutoMapper;
using IntuitivePaper.Domain.Interfaces;
using MediatR;


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

            if (invoice != null)
            {
                var invoiceItem = new Domain.Entities.InvoiceItem()
                {
                    Description = request.Description,
                    Quantity = request.Quantity,
                    UnitPrice = request.UnitPrice,
                    NetAmount = request.NetAmount,
                    TaxRate = request.TaxRate,
                    TaxAmount = request.TaxAmount,
                    GrossAmount = request.GrossAmount,
                    PKWiUorPKOB = request.PKWiUorPKOB,
                    UnitMeasure = request.UnitMeasure,
                    InvoiceId = invoice.Id
                };

                // Obliczanie kosztu faktury brutto
                invoiceItem.NetAmount = (invoiceItem.Quantity > 0) ? invoiceItem.Quantity.Value * invoiceItem.UnitPrice : invoiceItem.UnitPrice;
                invoiceItem.TaxAmount = invoiceItem.NetAmount * (invoiceItem.TaxRate / 100);
                invoiceItem.GrossAmount = invoiceItem.NetAmount + invoiceItem.TaxAmount;

                await _invoiceItemRepository.Create(invoiceItem);

                // Aktualizacja sumy kwot na fakturze
                invoice.TotalNetAmount += invoiceItem.NetAmount;
                invoice.TotalTaxAmount += invoiceItem.TaxAmount;
                invoice.TotalGrossAmount += invoiceItem.GrossAmount;

                // Zamiana decimala na słowo
                invoice.NumberAsWords = NumberToWordConverter.AmountInWords(invoice.TotalGrossAmount, "PLN");
                // Zapisanie zmian w repozytorium faktur
                await _invoiceRepository.Update(invoice);
            }

            return Unit.Value;
        }
    }
}
