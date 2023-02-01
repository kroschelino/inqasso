using Microsoft.EntityFrameworkCore;
using Inqasso.Core.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inqasso.Core.Context.Configurations;

internal class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("orders");

        builder.HasIndex(e => e.SupplierName, "orders$supplierId");

        builder.Property(e => e.Id).HasColumnName("ID");

        builder.Property(e => e.OrderDate)
            .HasPrecision(0)
            .HasColumnName("orderDate");

        builder.Property(e => e.Payer).HasColumnName("payer");

        builder.Property(e => e.SupplierName)
            .HasMaxLength(255)
            .HasColumnName("supplierName");

        builder.Property(e => e.Total)
            .HasColumnType("money")
            .HasColumnName("total")
            .HasDefaultValueSql("((0))");

        builder.HasOne(d => d.PayerNavigation)
            .WithMany(p => p.Orders)
            .HasForeignKey(d => d.Payer)
            .HasConstraintName("orders$membersorders");
    }
}