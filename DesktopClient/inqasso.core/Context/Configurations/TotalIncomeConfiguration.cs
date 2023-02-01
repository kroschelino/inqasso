using Microsoft.EntityFrameworkCore;
using Inqasso.Core.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inqasso.Core.Context.Configurations
{
    internal class TotalIncomeConfiguration : IEntityTypeConfiguration<TotalIncome>
    {
        public void Configure(EntityTypeBuilder<TotalIncome> builder)
        {
            builder.HasNoKey();

            builder.ToView("totalIncome");

            builder.Property(e => e.TotalIncome1)
                .HasColumnType("money")
                .HasColumnName("Total Income");
        }
    }
}
