using AutoMapper;
using IntuitivePaper.Application.Invoice.Commands.EditInvoice;
using IntuitivePaper.Application.Invoice.Dtos;
using IntuitivePaper.Application.InvoiceItem.Dtos;
using IntuitivePaper.Application.Services;

namespace IntuitivePaper.Application.Mappings
{
    public class InvoiceMappingProfile : Profile
    {
        public InvoiceMappingProfile()
        {
            Invoice();

            InvoiceItem();
        }

        /// <summary>
        /// Faktura
        /// </summary>
        public void Invoice()
        {
            CreateMap<InvoiceDto, Domain.Entities.Invoice>()
                .ReverseMap();

            CreateMap<InvoiceDto, EditInvoiceCommand>();
        }

        /// <summary>
        /// Dane na fakturze
        /// </summary>
        public void InvoiceItem()
        {
            CreateMap<InvoiceItemDto, Domain.Entities.InvoiceItem>()
                .ReverseMap();
        }
    }
}
