using Inqasso.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inqasso.Data.Context.Configurations;

internal class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.ToTable("orderItems");

        builder.Property(e => e.Id).HasColumnName("ID");

        builder.Property(e => e.Amount)
            .HasColumnName("amount")
            .HasDefaultValueSql("((0))");

        builder.Property(e => e.ExpectedIncome)
            .HasColumnType("money")
            .HasColumnName("expectedIncome");

        builder.Property(e => e.ItemName)
            .HasMaxLength(255)
            .HasColumnName("itemName");

        builder.Property(e => e.OrderId).HasColumnName("orderId");

        builder.Property(e => e.UnitPrice)
            .HasColumnType("money")
            .HasColumnName("unitPrice")
            .HasDefaultValueSql("((1))");

        builder.Property(e => e.UnitSize)
            .HasColumnName("unitSize")
            .HasDefaultValueSql("((0))");

        builder.HasOne(d => d.Order)
            .WithMany(p => p.OrderItems)
            .HasForeignKey(d => d.OrderId)
            .HasConstraintName("orderItems$ordersorderItems");
    }
}