using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HD.TVADOld.Entities.Entities
{
    [Table("tblLatCat")]
    public class TimeBandSlice
    {
        [Column("IDMaGio")]
        public int TimeBandId { get; set; }

        [ForeignKey(nameof(TimeBandId))]
        public TimeBand TimeBand { get; set; }

        [Column("LatCat")]
        public int SliceId { get; set; }

        [Column("ThoiLuongToiDaQuangCao")]
        public int? MaxDurationForBooking { get; set; }

        [Column("ThoiLuongDuocQuaQuangCao")]
        public int? DurationAddingForBooking { get; set; }

        [Column("ThoiLuongToiDaTaiTro")]
        public int? MaxDurationForSponsor { get; set; }

        [Column("ThoiLuongDuocQuaTaiTro")]
        public int? DurationAddingForSponsor { get; set; }

        public ICollection<TimeBandSliceDescription> Descriptions { get; } = new HashSet<TimeBandSliceDescription>();
        
        public ICollection<Spot> Spots { get; } = new HashSet<Spot>();
    }
}
