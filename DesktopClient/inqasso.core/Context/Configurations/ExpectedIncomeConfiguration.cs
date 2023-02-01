using Microsoft.EntityFrameworkCore;
using Inqasso.Core.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inqasso.Core.Context.Configurations;

internal class ExpectedIncomeConfiguration : IEntityTypeConfiguration<ExpectedIncome>
{
    public void Configure(EntityTypeBuilder<ExpectedIncome> builder)
    {
        builder.HasNoKey();

        builder.ToView("expectedIncome");

        builder.Property(e => e.ExpectedIncome1)
            .HasColumnType("money")
            .HasColumnName("Expected Income");
    }
}