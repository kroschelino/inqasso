using Microsoft.EntityFrameworkCore;
using Inqasso.Core.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inqasso.Core.Context.Configurations
{
    internal class RevenueConfiguration : IEntityTypeConfiguration<Revenue>
    {
        public void Configure(EntityTypeBuilder<Revenue> builder)
        {
            builder.HasNoKey();

            builder.ToView("revenue");

            builder.Property(e => e.Member).HasColumnName("member");

            builder.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");

            builder.Property(e => e.Revenue1)
                .HasColumnType("money")
                .HasColumnName("revenue");
        }
    }
}
