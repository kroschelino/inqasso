using Microsoft.EntityFrameworkCore;
using Inqasso.Core.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inqasso.Core.Context.Configurations
{
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
}
