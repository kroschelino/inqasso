using Microsoft.EntityFrameworkCore;
using Inqasso.Core.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inqasso.Core.Context.Configurations;

internal class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        builder.ToTable("transactions");

        builder.Property(e => e.Id).HasColumnName("id");

        builder.Property(e => e.Amount)
            .HasColumnType("smallmoney")
            .HasColumnName("amount");

        builder.Property(e => e.Date)
            .HasColumnType("date")
            .HasColumnName("date");

        builder.Property(e => e.Member).HasColumnName("member");

        builder.HasOne(d => d.MemberNavigation)
            .WithMany(p => p.Transactions)
            .HasForeignKey(d => d.Member)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_transactions_members1");
    }
}