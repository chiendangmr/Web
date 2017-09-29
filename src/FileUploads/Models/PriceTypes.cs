using System;
using System.Collections.Generic;

namespace FileUploads.Models
{
    public partial class PriceTypes
    {
        public PriceTypes()
        {
            BookingTypePriceTypes = new HashSet<BookingTypePriceTypes>();
            TypeDetails = new HashSet<TypeDetails>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<BookingTypePriceTypes> BookingTypePriceTypes { get; set; }
        public virtual ICollection<TypeDetails> TypeDetails { get; set; }
    }
}
