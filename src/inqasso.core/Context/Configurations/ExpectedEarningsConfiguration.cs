using Microsoft.EntityFrameworkCore;
using Inqasso.Core.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inqasso.Core.Context.Configurations;

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