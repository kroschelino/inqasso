using System.Text.Json;
using Inqasso.Core.Models;
using Microsoft.EntityFrameworkCore;
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
                v => JsonSerializer.Serialize(v, (JsonSerializerOptions?)null),
                v => JsonSerializer.Deserialize<IEnumerable<int>>(v, (JsonSerializerOptions?)null)
            ).HasColumnName("typicalSizes");
    }
}