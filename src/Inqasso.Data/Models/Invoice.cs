namespace Inqasso.Data.Models;

internal class Invoice
{
    public Invoice()
    {
        InvoiceItems = new HashSet<InvoiceItem>();
    }

    public int Id { get; set; }
    public DateTime? InvoiceDate { get; set; }

    public virtual ICollection<InvoiceItem> InvoiceItems { get; set; }
}