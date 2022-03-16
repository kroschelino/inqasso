using System;
using System.Collections.Generic;
using Inqasso.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Inqasso.Core
{
    internal partial class inqassoContext : DbContext
    {
        public inqassoContext()
        {
        }

        public inqassoContext(DbContextOptions<inqassoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Balance> Balances { get; set; } = null!;
        public virtual DbSet<ExpectedEarning> ExpectedEarnings { get; set; } = null!;
        public virtual DbSet<ExpectedIncome> ExpectedIncomes { get; set; } = null!;
        public virtual DbSet<Invoice> Invoices { get; set; } = null!;
        public virtual DbSet<InvoiceItem> InvoiceItems { get; set; } = null!;
        public virtual DbSet<Member> Members { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderItem> OrderItems { get; set; } = null!;
        public virtual DbSet<Overdue> Overdues { get; set; } = null!;
        public virtual DbSet<PriceLevel> PriceLevels { get; set; } = null!;
        public virtual DbSet<RealEarning> RealEarnings { get; set; } = null!;
        public virtual DbSet<Revenue> Revenues { get; set; } = null!;
        public virtual DbSet<TotalExpense> TotalExpenses { get; set; } = null!;
        public virtual DbSet<TotalIncome> TotalIncomes { get; set; } = null!;
        public virtual DbSet<Transaction> Transactions { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-NNKB45B\\SQLEXPRESS;Initial Catalog=inqasso;Integrated Security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Balance>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("balances");

                entity.Property(e => e.Balance1)
                    .HasColumnType("money")
                    .HasColumnName("balance");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.In)
                    .HasColumnType("money")
                    .HasColumnName("in");

                entity.Property(e => e.Member)
                    .HasMaxLength(255)
                    .HasColumnName("member");

                entity.Property(e => e.Out)
                    .HasColumnType("money")
                    .HasColumnName("out");
            });

            modelBuilder.Entity<ExpectedEarning>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("expectedEarnings");

                entity.Property(e => e.ExpectedEarnings)
                    .HasColumnType("money")
                    .HasColumnName("Expected Earnings");
            });

            modelBuilder.Entity<ExpectedIncome>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("expectedIncome");

                entity.Property(e => e.ExpectedIncome1)
                    .HasColumnType("money")
                    .HasColumnName("Expected Income");
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.ToTable("invoices");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.InvoiceDate)
                    .HasPrecision(0)
                    .HasColumnName("invoiceDate");
            });

            modelBuilder.Entity<InvoiceItem>(entity =>
            {
                entity.ToTable("invoiceItems");

                entity.HasIndex(e => e.Paid, "invoiceItems$paid");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Amount)
                    .HasMaxLength(255)
                    .HasColumnName("amount");

                entity.Property(e => e.InvoiceId).HasColumnName("invoiceId");

                entity.Property(e => e.MemberId).HasColumnName("memberId");

                entity.Property(e => e.Paid)
                    .HasColumnName("paid")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PriceLevelId).HasColumnName("priceLevelId");

                entity.Property(e => e.SsmaTimeStamp)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("SSMA_TimeStamp");

                entity.Property(e => e.Total)
                    .HasColumnType("money")
                    .HasColumnName("total");

                entity.Property(e => e.UnitPrice)
                    .HasColumnType("money")
                    .HasColumnName("unitPrice")
                    .HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Invoice)
                    .WithMany(p => p.InvoiceItems)
                    .HasForeignKey(d => d.InvoiceId)
                    .HasConstraintName("invoiceItems$invoicesinvoiceItems");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.InvoiceItems)
                    .HasForeignKey(d => d.MemberId)
                    .HasConstraintName("invoiceItems$membersinvoiceItems");

                entity.HasOne(d => d.PriceLevel)
                    .WithMany(p => p.InvoiceItems)
                    .HasForeignKey(d => d.PriceLevelId)
                    .HasConstraintName("FK_invoiceItems_priceLevels");
            });

            modelBuilder.Entity<Member>(entity =>
            {
                entity.ToTable("members");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.ClubMember)
                    .HasColumnName("clubMember")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.MemberName)
                    .HasMaxLength(255)
                    .HasColumnName("memberName");

                entity.Property(e => e.ShortName)
                    .HasMaxLength(255)
                    .HasColumnName("shortName");

                entity.Property(e => e.SsmaTimeStamp)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("SSMA_TimeStamp");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("orders");

                entity.HasIndex(e => e.SupplierName, "orders$supplierId");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.OrderDate)
                    .HasPrecision(0)
                    .HasColumnName("orderDate");

                entity.Property(e => e.Payer).HasColumnName("payer");

                entity.Property(e => e.SupplierName)
                    .HasMaxLength(255)
                    .HasColumnName("supplierName");

                entity.Property(e => e.Total)
                    .HasColumnType("money")
                    .HasColumnName("total")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.PayerNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.Payer)
                    .HasConstraintName("orders$membersorders");
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.ToTable("orderItems");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ExpectedIncome)
                    .HasColumnType("money")
                    .HasColumnName("expectedIncome");

                entity.Property(e => e.ItemName)
                    .HasMaxLength(255)
                    .HasColumnName("itemName");

                entity.Property(e => e.OrderId).HasColumnName("orderId");

                entity.Property(e => e.UnitPrice)
                    .HasColumnType("money")
                    .HasColumnName("unitPrice")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.UnitSize)
                    .HasColumnName("unitSize")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("orderItems$ordersorderItems");
            });

            modelBuilder.Entity<Overdue>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("overdue");

                entity.Property(e => e.MemberName)
                    .HasMaxLength(255)
                    .HasColumnName("memberName");

                entity.Property(e => e.Pending).HasColumnType("money");

                entity.Property(e => e.ShortName)
                    .HasMaxLength(255)
                    .HasColumnName("shortName");
            });

            modelBuilder.Entity<PriceLevel>(entity =>
            {
                entity.ToTable("priceLevels");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.Amount)
                    .HasColumnType("smallmoney")
                    .HasColumnName("amount");

                entity.Property(e => e.Color)
                    .HasMaxLength(3)
                    .HasColumnName("color")
                    .HasDefaultValueSql("(0x000000)")
                    .IsFixedLength();
            });

            modelBuilder.Entity<RealEarning>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("realEarnings");

                entity.Property(e => e.RealEarnings)
                    .HasColumnType("money")
                    .HasColumnName("Real Earnings");
            });

            modelBuilder.Entity<Revenue>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("revenue");

                entity.Property(e => e.Member).HasColumnName("member");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.Revenue1)
                    .HasColumnType("money")
                    .HasColumnName("revenue");
            });

            modelBuilder.Entity<TotalExpense>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("totalExpenses");

                entity.Property(e => e.TotalExpenses)
                    .HasColumnType("money")
                    .HasColumnName("Total Expenses");
            });

            modelBuilder.Entity<TotalIncome>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("totalIncome");

                entity.Property(e => e.TotalIncome1)
                    .HasColumnType("money")
                    .HasColumnName("Total Income");
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.ToTable("transactions");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Amount)
                    .HasColumnType("smallmoney")
                    .HasColumnName("amount");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date");

                entity.Property(e => e.Member).HasColumnName("member");

                entity.HasOne(d => d.MemberNavigation)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.Member)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_transactions_members1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
