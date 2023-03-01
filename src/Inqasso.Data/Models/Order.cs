namespace Inqasso.Data.Models;

internal class Order
{
    public Order()
    {
        OrderItems = new HashSet<OrderItem>();
    }

    public int Id { get; set; }
    public string? SupplierName { get; set; }
    public DateTime? OrderDate { get; set; }
    public decimal? Total { get; set; }
    public int? Payer { get; set; }

    public virtual Member? PayerNavigation { get; set; }
    public virtual ICollection<OrderItem> OrderItems { get; set; }
}