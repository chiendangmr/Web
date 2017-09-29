using System;
using System.Collections.Generic;

namespace FileUploads.Models
{
    public partial class RetailPrices
    {
        public Guid Id { get; set; }
        public Guid RetailTypeId { get; set; }
        public DateTime StartDate { get; set; }
        public decimal Price { get; set; }

        public virtual RetailTypes RetailType { get; set; }
    }
}
