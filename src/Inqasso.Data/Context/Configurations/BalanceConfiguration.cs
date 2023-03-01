using Inqasso.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inqasso.Data.Context.Configurations;

internal class BalanceConfiguration : IEntityTypeConfiguration<Balance>
{
    public void Configure(EntityTypeBuilder<Balance> builder)
    {
        builder.HasNoKey();

        builder.ToView("balances");

        builder.Property(e => e.Balance1)
            .HasColumnType("money")
            .HasColumnName("balance");

        builder.Property(e => e.Id).HasColumnName("ID");

        builder.Property(e => e.In)
            .HasColumnType("money")
            .HasColumnName("in");

        builder.Property(e => e.Member)
            .HasMaxLength(255)
            .HasColumnName("member");

        builder.Property(e => e.Out)
            .HasColumnType("money")
            .HasColumnName("out");
    }
}