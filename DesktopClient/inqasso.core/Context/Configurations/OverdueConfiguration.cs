using Microsoft.EntityFrameworkCore;
using Inqasso.Core.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inqasso.Core.Context.Configurations;

internal class OverdueConfiguration : IEntityTypeConfiguration<Overdue>
{
    public void Configure(EntityTypeBuilder<Overdue> builder)
    {
        builder.HasNoKey();

        builder.ToView("overdue");

        builder.Property(e => e.MemberName)
            .HasMaxLength(255)
            .HasColumnName("memberName");

        builder.Property(e => e.Pending).HasColumnType("money");

        builder.Property(e => e.ShortName)
            .HasMaxLength(255)
            .HasColumnName("shortName");
    }
}