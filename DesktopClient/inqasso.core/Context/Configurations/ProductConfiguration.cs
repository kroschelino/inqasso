using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Inqasso.Core.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inqasso.Core.Context.Configurations;

internal class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("products");

        builder.Property(e => e.Id).HasColumnName("id");

        builder.Property(e => e.Producer)
            .HasMaxLength(50)
            .HasColumnName("producer");

        builder.Property(e => e.Name).HasMaxLength(50).HasColumnName("name");

        builder.Property(e => e.Flavor)
            .HasMaxLength(50)
            .HasColumnName("flavor");

        builder.Property(e => e.TypicalSizes)
            .HasConversion(
                v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null!),
                (v) => Deserialize(v)
            ).HasColumnName("typicalSizes");
    }
}