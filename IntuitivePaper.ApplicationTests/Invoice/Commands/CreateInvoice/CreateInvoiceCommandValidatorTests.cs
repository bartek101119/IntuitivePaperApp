using Xunit;
using IntuitivePaper.Application.Invoice.Commands.CreateInvoice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;
using static System.Runtime.InteropServices.JavaScript.JSType;
using FluentValidation.TestHelper;

namespace IntuitivePaper.Application.Invoice.Commands.CreateInvoice.Tests
{
    public class CreateInvoiceCommandValidatorTests
    {
        [Fact()]
        public void Validate_ForValidObject_ShouldNotHaveAnyValidationErrors()
        {
            var commandValidator = new CreateInvoiceCommandValidator();
            var invoiceCommand = new CreateInvoiceCommand()
            {
                Id = 1,
                Number = "Test",
                Date = new DateTime(2023, 1, 1),
                PlaceOfIssue = "Test",
                SaleDate = new DateTime(2023, 1, 1),
                PaymentDate = new DateTime(2023, 1, 1),
                PaymentMethod = "Test",
                Bank = "Test",
                AccountNumber = "Test",
                SellerName = "Test",
                SellerAddress = "Test",
                SellerTaxId = "1234567899",
                BuyerName = "Test",
                BuyerAddress = "Test",
                BuyerTaxId = "1234567899",
                TotalGrossAmount = 12,
                TotalNetAmount = 12,
                TotalTaxAmount = 12,
                DateCreatedUtc = new DateTime(2023, 1, 1),
                IsEditable = true,
            };

            var result = commandValidator.TestValidate(invoiceCommand);

            result.ShouldNotHaveAnyValidationErrors();
        }

        [Fact()]
        public void Validate_ForInvalidObject_ShouldHaveAnyValidationError()
        {
            var commandValidator = new CreateInvoiceCommandValidator();
            var invoiceCommand = new CreateInvoiceCommand()
            {
                Id = 1,
                Number = "Test",
                Date = new DateTime(2023, 1, 1),
                PlaceOfIssue = "Test",
                SaleDate = new DateTime(2023, 1, 1),
                PaymentDate = new DateTime(2023, 1, 1),
                PaymentMethod = "Test",
                Bank = "Test",
                AccountNumber = "Test",
                SellerName = "Test",
                SellerAddress = "Test",
                SellerTaxId = "1",
                BuyerName = "Test",
                BuyerAddress = "Test",
                BuyerTaxId = "1",
                TotalGrossAmount = 12,
                TotalNetAmount = 12,
                TotalTaxAmount = 12,
                DateCreatedUtc = new DateTime(2023, 1, 1),
                IsEditable = true,
            };

            var result = commandValidator.TestValidate(invoiceCommand);

            result.ShouldHaveAnyValidationError(); // nip
        }
    }
}