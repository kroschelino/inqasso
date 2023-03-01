using Inqasso.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inqasso.Data.Context.Configurations;

internal class RealEarningConfiguration : IEntityTypeConfiguration<RealEarning>
{
    public void Configure(EntityTypeBuilder<RealEarning> builder)
    {
        builder.HasNoKey();

        builder.ToView("realEarnings");

        builder.Property(e => e.RealEarnings)
            .HasColumnType("money")
            .HasColumnName("Real Earnings");
    }
}