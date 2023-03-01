using Inqasso.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inqasso.Data.Context.Configurations;

internal class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
{
    public void Configure(EntityTypeBuilder<Invoice> builder)
    {
        builder.ToTable("invoices");

        builder.Property(e => e.Id).HasColumnName("ID");

        builder.Property(e => e.InvoiceDate)
            .HasPrecision(0)
            .HasColumnName("invoiceDate");
    }
}