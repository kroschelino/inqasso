namespace Inqasso.Core.Models
{
    public partial class Balance
    {
        public int Id { get; set; }
        public string? Member { get; set; }
        public decimal? Out { get; set; }
        public decimal? In { get; set; }
        public decimal? Balance1 { get; set; }
    }
}
