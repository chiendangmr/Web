using System;
using System.Collections.Generic;

namespace FileUploads.Models
{
    public partial class BookingTypes
    {
        public BookingTypes()
        {
            AnnexContracts = new HashSet<AnnexContracts>();
            AnnexContractTypes = new HashSet<AnnexContractTypes>();
            BookingTypePriceTypes = new HashSet<BookingTypePriceTypes>();
            TimeBandSliceDurationByTypes = new HashSet<TimeBandSliceDurationByTypes>();
            TimeBandSliceForTypes = new HashSet<TimeBandSliceForTypes>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? ParentId { get; set; }

        public virtual ICollection<AnnexContracts> AnnexContracts { get; set; }
        public virtual ICollection<AnnexContractTypes> AnnexContractTypes { get; set; }
        public virtual ICollection<BookingTypePriceTypes> BookingTypePriceTypes { get; set; }
        public virtual ICollection<TimeBandSliceDurationByTypes> TimeBandSliceDurationByTypes { get; set; }
        public virtual ICollection<TimeBandSliceForTypes> TimeBandSliceForTypes { get; set; }
        public virtual BookingTypes Parent { get; set; }
        public virtual ICollection<BookingTypes> InverseParent { get; set; }
    }
}
