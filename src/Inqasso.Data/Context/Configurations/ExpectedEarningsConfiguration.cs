using Inqasso.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inqasso.Data.Context.Configurations;

internal class ExpectedEarningsConfiguration : IEntityTypeConfiguration<ExpectedEarning>
{
    public void Configure(EntityTypeBuilder<ExpectedEarning> builder)
    {
        builder.HasNoKey();

        builder.ToView("expectedEarnings");

        builder.Property(e => e.ExpectedEarnings)
            .HasColumnType("money")
            .HasColumnName("Expected Earnings");
    }
}