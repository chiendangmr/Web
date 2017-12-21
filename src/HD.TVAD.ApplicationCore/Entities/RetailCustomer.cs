using System;
using System.Collections.Generic;

namespace HD.TVAD.ApplicationCore.Entities
{
    public partial class RetailCustomer
    {
        public RetailCustomer()
        {
        }

        public Guid Id { get; set; }
		
        public virtual Customer Customer { get; set; }
    }
}
