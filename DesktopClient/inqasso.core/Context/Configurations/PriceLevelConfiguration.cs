using Microsoft.EntityFrameworkCore;
using Inqasso.Core.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inqasso.Core.Context.Configurations;

internal class PriceLevelConfiguration : IEntityTypeConfiguration<PriceLevel>
{
    public void Configure(EntityTypeBuilder<PriceLevel> builder)
    {
        builder.ToTable("priceLevels");

        builder.Property(e => e.Id).HasColumnName("id");

        builder.Property(e => e.Active).HasColumnName("active");

        builder.Property(e => e.Amount)
            .HasColumnType("smallmoney")
            .HasColumnName("amount");

        builder.Property(e => e.Color)
            .HasMaxLength(3)
            .HasColumnName("color")
            .HasDefaultValueSql("(0x000000)")
            .IsFixedLength();
    }
}