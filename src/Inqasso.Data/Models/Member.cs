namespace Inqasso.Data.Models;

internal class Member
{
    internal Member()
    {
        InvoiceItems = new HashSet<InvoiceItem>();
        Orders = new HashSet<Order>();
        Transactions = new HashSet<Transaction>();
    }

    internal int Id { get; set; }
    internal string? MemberName { get; set; }
    internal string? ShortName { get; set; }
    internal bool? ClubMember { get; set; }
    internal byte[] SsmaTimeStamp { get; set; } = null!;
    internal bool? Active { get; set; }

    internal virtual ICollection<InvoiceItem> InvoiceItems { get; set; }
    internal virtual ICollection<Order> Orders { get; set; }
    internal virtual ICollection<Transaction> Transactions { get; set; }
}