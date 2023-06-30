using AutoMapper;
using IntuitivePaper.Application.Invoice.Commands.EditInvoice;
using IntuitivePaper.Application.Invoice.Dtos;
using IntuitivePaper.Application.InvoiceItem.Dtos;
using IntuitivePaper.Application.Services;
using IntuitivePaper.Application.User;

namespace IntuitivePaper.Application.Mappings
{
    public class InvoiceMappingProfile : Profile
    {
        public InvoiceMappingProfile(IUserContext userContext)
        {
            Invoice(userContext);

            InvoiceItem();
        }

        /// <summary>
        /// Faktura
        /// </summary>
        public void Invoice(IUserContext userContext)
        {
            var user = userContext.GetCurrentUser();

            CreateMap<InvoiceDto, Domain.Entities.Invoice>()
                .ForMember(x => x.NumberAsWords, y => y.Ignore())
                .ReverseMap()
                .ForMember(x => x.IsEditable, m => m.MapFrom(s => user != null && s.CreatedById == user.Id));

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
