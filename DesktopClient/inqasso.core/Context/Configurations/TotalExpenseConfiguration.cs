using Microsoft.EntityFrameworkCore;
using Inqasso.Core.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inqasso.Core.Context.Configurations
{
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
}
