using System;
using System.Collections.Generic;

namespace Inqasso.Core
{
    public partial class PriceLevel
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
}
