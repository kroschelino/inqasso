using System.Text.Json;
using Inqasso.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Inqasso.Core.Context;

internal class InqassoContext : DbContext
{
    public InqassoContext()
    {
    }

    public InqassoContext(DbContextOptions<InqassoContext> options)
        : base(options)
    {
    }

    internal virtual DbSet<Balance> Balances { get; set; } = null!;
    internal virtual DbSet<ExpectedEarning> ExpectedEarnings { get; set; } = null!;
    internal virtual DbSet<ExpectedIncome> ExpectedIncomes { get; set; } = null!;
    internal virtual DbSet<Invoice> Invoices { get; set; } = null!;
    internal virtual DbSet<InvoiceItem> InvoiceItems { get; set; } = null!;
    internal virtual DbSet<Member> Members { get; set; } = null!;
    internal virtual DbSet<Order> Orders { get; set; } = null!;
    internal virtual DbSet<OrderItem> OrderItems { get; set; } = null!;
    internal virtual DbSet<Overdue> Overdues { get; set; } = null!;
    internal virtual DbSet<PriceLevel> PriceLevels { get; set; } = null!;
    internal virtual DbSet<RealEarning> RealEarnings { get; set; } = null!;
    internal virtual DbSet<Revenue> Revenues { get; set; } = null!;
    internal virtual DbSet<TotalExpense> TotalExpenses { get; set; } = null!;
    internal virtual DbSet<TotalIncome> TotalIncomes { get; set; } = null!;
    internal virtual DbSet<Transaction> Transactions { get; set; } = null!;
    internal virtual DbSet<Product> Products { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https: //go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
            optionsBuilder.UseSqlServer(
                "Data Source=DESKTOP-1DDPI62\\SQLEXPRESS;Initial Catalog=inqasso;Integrated Security=true");
        }
    }

    private static List<int> Deserialize(string v)
    {
        List<int> result;
        try
        {
            result = JsonSerializer.Deserialize<List<int>>(v) ?? new List<int> { 1 };
        }
        catch (JsonException)
        {
            result = new List<int> { 1 };
        }

        return result;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(InqassoContext).Assembly);
    }
}