namespace Inqasso.Data.Models;

internal class PriceLevel
{
    public PriceLevel()
    {
        InvoiceItems = new HashSet<InvoiceItem>();
    }

    public int Id { get; set; }
    public decimal? Amount { get; set; }
    public byte[]? Color { get; set; }
    public bool? Active { get; set; }

    public virtual ICollection<InvoiceItem> InvoiceItems { get; set; }
}