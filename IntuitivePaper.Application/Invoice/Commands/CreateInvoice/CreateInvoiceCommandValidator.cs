using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntuitivePaper.Application.Invoice.Commands.CreateInvoice
{
    public class CreateInvoiceCommandValidator : AbstractValidator<CreateInvoiceCommand>
    {
        public CreateInvoiceCommandValidator()
        {
            RuleFor(x => x.Number).NotEmpty().WithMessage("Numer faktury jest wymagany.");
            RuleFor(x => x.Date).NotEmpty().WithMessage("Data wystawienia jest wymagana.");
            RuleFor(x => x.SellerName).NotEmpty().WithMessage("Nazwa sprzedawcy jest wymagana.");
            RuleFor(x => x.SellerAddress).NotEmpty().WithMessage("Adres sprzedawcy jest wymagany.");
            RuleFor(x => x.SellerTaxId).NotEmpty().MaximumLength(50).WithMessage("NIP sprzedawcy jest wymagany.");
            RuleFor(x => x.BuyerName).NotEmpty().WithMessage("Nazwa nabywcy jest wymagana.");
            RuleFor(x => x.BuyerAddress).NotEmpty().WithMessage("Adres nabywcy jest wymagany.");
            RuleFor(x => x.BuyerTaxId).NotEmpty().WithMessage("NIP nabywcy jest wymagany.");
        }
    }

}
