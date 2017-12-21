using System;
using System.Collections.Generic;

namespace HD.TVAD.ApplicationCore.Entities
{
    public partial class PriceType
    {
        public PriceType()
        {
            BookingTypePriceTypes = new HashSet<BookingTypePriceType>();
            TypeDetails = new HashSet<TypeDetail>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<BookingTypePriceType> BookingTypePriceTypes { get; set; }
        public virtual ICollection<TypeDetail> TypeDetails { get; set; }
    }
}
