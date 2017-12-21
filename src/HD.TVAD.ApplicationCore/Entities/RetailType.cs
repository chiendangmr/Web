using System;
using System.Collections.Generic;

namespace HD.TVAD.ApplicationCore.Entities
{
    public partial class RetailType
    {
        public RetailType()
        {
            RetailPrices = new HashSet<RetailPrice>();
        }

        public Guid Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<RetailPrice> RetailPrices { get; set; }
        public virtual TypeDetail TypeDetail { get; set; }
    }
}
