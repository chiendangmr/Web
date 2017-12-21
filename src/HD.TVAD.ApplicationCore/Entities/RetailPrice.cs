using System;
using System.Collections.Generic;

namespace HD.TVAD.ApplicationCore.Entities
{
    public partial class RetailPrice
    {
        public Guid Id { get; set; }
        public Guid RetailTypeId { get; set; }
        public DateTime StartDate { get; set; }
        public decimal Price { get; set; }

        public virtual RetailType RetailType { get; set; }
    }
}
