using Microsoft.EntityFrameworkCore;
using Inqasso.Core.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inqasso.Core.Context.Configurations;

internal class MemberConfiguration : IEntityTypeConfiguration<Member>
{
    public void Configure(EntityTypeBuilder<Member> builder)
    {
        builder.ToTable("members");

        builder.Property(e => e.Id).HasColumnName("ID");

        builder.Property(e => e.Active).HasColumnName("active");

        builder.Property(e => e.ClubMember)
            .HasColumnName("clubMember")
            .HasDefaultValueSql("((0))");

        builder.Property(e => e.MemberName)
            .HasMaxLength(255)
            .HasColumnName("memberName");

        builder.Property(e => e.ShortName)
            .HasMaxLength(255)
            .HasColumnName("shortName");

        builder.Property(e => e.SsmaTimeStamp)
            .IsRowVersion()
            .IsConcurrencyToken()
            .HasColumnName("SSMA_TimeStamp");
    }
}