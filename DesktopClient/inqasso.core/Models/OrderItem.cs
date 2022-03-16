using System;
using System.Collections.Generic;

namespace Inqasso.Core
{
    public partial class OrderItem
    {
        public int Id { get; set; }
        public int? OrderId { get; set; }
        public string? ItemName { get; set; }
        public int? Amount { get; set; }
        public int? UnitSize { get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal? ExpectedIncome { get; set; }

        public virtual Order? Order { get; set; }
    }
}
