using System;
using System.Collections.Generic;

namespace FileUploads.Models
{
    public partial class RetailTypes
    {
        public RetailTypes()
        {
            RetailPrices = new HashSet<RetailPrices>();
        }

        public Guid Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<RetailPrices> RetailPrices { get; set; }
        public virtual TypeDetails IdNavigation { get; set; }
    }
}
