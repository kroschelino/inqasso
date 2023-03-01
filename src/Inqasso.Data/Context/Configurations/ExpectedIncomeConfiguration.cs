using Inqasso.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inqasso.Data.Context.Configurations;

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