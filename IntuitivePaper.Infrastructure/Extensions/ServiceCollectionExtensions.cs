using IntuitivePaper.Domain.Interfaces;
using IntuitivePaper.Infrastructure.Data;
using IntuitivePaper.Infrastructure.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntuitivePaper.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IntuitivePaperContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("IntuitivePaperContext")));

            services.AddDefaultIdentity<IdentityUser>()
                .AddEntityFrameworkStores<IntuitivePaperContext>();

            services.AddScoped<IInvoiceRepository, InvoiceRepository>();

            services.AddScoped<IInvoiceItemRepository, InvoiceItemRepository>();
        }
    }
}
