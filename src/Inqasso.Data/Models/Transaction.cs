namespace Inqasso.Data.Models;

internal class Transaction
{
    internal int Id { get; set; }
    internal int Member { get; set; }
    internal DateTime Date { get; set; }
    internal decimal? Amount { get; set; }

    internal virtual Member MemberNavigation { get; set; } = null!;
}