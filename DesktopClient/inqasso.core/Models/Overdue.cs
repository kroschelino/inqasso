namespace Inqasso.Core.Models
{
    public partial class Overdue
    {
        public string? ShortName { get; set; }
        public string? MemberName { get; set; }
        public decimal? Pending { get; set; }
    }
}
