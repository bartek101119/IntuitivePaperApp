using IntuitivePaper.Domain.Entities;
using IntuitivePaper.Infrastructure.SeederService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntuitivePaper.Infrastructure.Data
{
    public class IntuitivePaperContext : DbContext
    {
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceItem> InvoiceItems { get; set; }
        public IntuitivePaperContext(DbContextOptions<IntuitivePaperContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Invoice>()
            .HasMany(i => i.Items)
            .WithOne(ii => ii.Invoice)
            .HasForeignKey(ii => ii.InvoiceId);

            //InvoiceSeeder.Seed(modelBuilder);
        }

    }
}
