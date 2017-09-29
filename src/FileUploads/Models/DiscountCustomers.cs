using System;
using System.Collections.Generic;

namespace FileUploads.Models
{
    public partial class DiscountCustomers
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal Rate { get; set; }
        public string Description { get; set; }

        public virtual Customers Customer { get; set; }
    }
}
