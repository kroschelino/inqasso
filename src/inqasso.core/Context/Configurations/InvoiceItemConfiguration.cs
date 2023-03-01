using Inqasso.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inqasso.Core.Context.Configurations;

internal class InvoiceItemConfiguration : IEntityTypeConfiguration<InvoiceItem>
{
    public void Configure(EntityTypeBuilder<InvoiceItem> builder)
    {
        builder.ToTable("invoiceItems");

        builder.HasIndex(e => e.Paid, "invoiceItems$paid");

        builder.Property(e => e.Id).HasColumnName("ID");

        builder.Property(e => e.Amount)
            .HasMaxLength(255)
            .HasColumnName("amount");

        builder.Property(e => e.InvoiceId).HasColumnName("invoiceId");

        builder.Property(e => e.MemberId).HasColumnName("memberId");

        builder.Property(e => e.Paid)
            .HasColumnName("paid")
            .HasDefaultValueSql("((0))");

        builder.Property(e => e.PriceLevelId).HasColumnName("priceLevelId");

        builder.Property(e => e.SsmaTimeStamp)
            .IsRowVersion()
            .IsConcurrencyToken()
            .HasColumnName("SSMA_TimeStamp");

        builder.Property(e => e.Total)
            .HasColumnType("money")
            .HasColumnName("total");

        builder.Property(e => e.UnitPrice)
            .HasColumnType("money")
            .HasColumnName("unitPrice")
            .HasDefaultValueSql("((1))");

        builder.HasOne(d => d.Invoice)
            .WithMany(p => p.InvoiceItems)
            .HasForeignKey(d => d.InvoiceId)
            .HasConstraintName("invoiceItems$invoicesinvoiceItems");

        builder.HasOne(d => d.Member)
            .WithMany(p => p.InvoiceItems)
            .HasForeignKey(d => d.MemberId)
            .HasConstraintName("invoiceItems$membersinvoiceItems");

        builder.HasOne(d => d.PriceLevel)
            .WithMany(p => p.InvoiceItems)
            .HasForeignKey(d => d.PriceLevelId)
            .HasConstraintName("FK_invoiceItems_priceLevels");
    }
}