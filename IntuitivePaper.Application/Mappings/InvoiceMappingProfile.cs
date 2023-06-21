using AutoMapper;
using IntuitivePaper.Application.Invoice.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntuitivePaper.Application.Mappings
{
    public class InvoiceMappingProfile : Profile
    {
        public InvoiceMappingProfile()
        {
            CreateMap<InvoiceDto, Domain.Entities.Invoice>();
        }
    }
}
