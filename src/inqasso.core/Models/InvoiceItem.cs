namespace Inqasso.Core.Models
{
    internal partial class InvoiceItem
    {
        public int Id { get; set; }
        public int? InvoiceId { get; set; }
        public int? MemberId { get; set; }
        public string? Amount { get; set; }
        public int? PriceLevelId { get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal? Total { get; set; }
        public bool? Paid { get; set; }
        public byte[] SsmaTimeStamp { get; set; } = null!;

        public virtual Invoice? Invoice { get; set; }
        public virtual Member? Member { get; set; }
        public virtual PriceLevel? PriceLevel { get; set; }
    }
}
