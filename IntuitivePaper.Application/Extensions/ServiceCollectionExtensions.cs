using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using IntuitivePaper.Application.Invoice.Commands.CreateInvoice;
using IntuitivePaper.Application.Mappings;
using FluentValidation;
using FluentValidation.AspNetCore;
using IntuitivePaper.Domain.Interfaces;
using IntuitivePaper.Application.Services;

namespace IntuitivePaper.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(typeof(CreateInvoiceCommand));

            services.AddAutoMapper(typeof(InvoiceMappingProfile));

            services.AddScoped<IPdfService, PdfService>();

            services.AddValidatorsFromAssemblyContaining<CreateInvoiceCommandValidator>()
                .AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();
        }
    }
}
