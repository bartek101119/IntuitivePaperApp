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
using IntuitivePaper.Application.User;
using AutoMapper;

namespace IntuitivePaper.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(typeof(CreateInvoiceCommand));

            services.AddScoped(provider => new MapperConfiguration(cfg =>
            {
                var scope = provider.CreateScope();
                var userContext = scope.ServiceProvider.GetRequiredService<IUserContext>();
                cfg.AddProfile(new InvoiceMappingProfile(userContext));
            }).CreateMapper()
            );

            services.AddScoped<IPdfService, PdfService>();

            services.AddValidatorsFromAssemblyContaining<CreateInvoiceCommandValidator>()
                .AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();

            services.AddScoped<IUserContext, UserContext>();
        }
    }
}
