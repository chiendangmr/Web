using System;
using System.Collections.Generic;

namespace HD.TVAD.ApplicationCore.Entities
{
    public partial class BookingType
    {
        public BookingType()
        {
            AnnexContracts = new HashSet<AnnexContract>();
            BookingTypePriceTypes = new HashSet<BookingTypePriceType>();
            TimeBandSliceDurationByTypes = new HashSet<TimeBandSliceDurationByType>();
            TimeBandSliceForTypes = new HashSet<TimeBandSliceForType>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? ParentId { get; set; }

        public virtual ICollection<AnnexContract> AnnexContracts { get; set; }
		public virtual ICollection<AnnexContractType> AnnexContractTypes { get; set; }
		public virtual ICollection<BookingTypePriceType> BookingTypePriceTypes { get; set; }
        public virtual ICollection<TimeBandSliceDurationByType> TimeBandSliceDurationByTypes { get; set; }
        public virtual ICollection<TimeBandSliceForType> TimeBandSliceForTypes { get; set; }
        public virtual BookingType Parent { get; set; }
        public virtual ICollection<BookingType> InverseParent { get; set; }
    }
}
