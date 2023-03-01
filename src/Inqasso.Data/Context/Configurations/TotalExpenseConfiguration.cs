using Inqasso.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inqasso.Data.Context.Configurations;

internal class TotalExpenseConfiguration : IEntityTypeConfiguration<TotalExpense>
{
    public void Configure(EntityTypeBuilder<TotalExpense> builder)
    {
        builder.HasNoKey();

        builder.ToView("totalExpenses");

        builder.Property(e => e.TotalExpenses)
            .HasColumnType("money")
            .HasColumnName("Total Expenses");
    }
}