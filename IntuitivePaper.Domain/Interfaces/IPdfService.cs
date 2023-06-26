using IntuitivePaper.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntuitivePaper.Domain.Interfaces
{
    public interface IPdfService
    {
        byte[] GeneratePdf(Invoice invoice);
    }
}
