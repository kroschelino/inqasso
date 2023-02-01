using Microsoft.EntityFrameworkCore;
using Inqasso.Core.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inqasso.Core.Context.Configurations;

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