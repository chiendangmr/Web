using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HD.TVADOld.Entities.Entities
{
    [Table("tblGhiChuLatCat")]
    public class TimeBandSliceDescription
    {
        [Column("IDMaGio")]
        public int TimeBandId { get; set; }

        [Column("LatCat")]
        public int SliceId { get; set; }

        public TimeBandSlice Slice { get; set; }

        [Column("ThuApDung")]
        public DayOfWeek DayOfWeeks { get; set; }

        [Column("TuNgay")]
        public DateTime StartDate { get; set; }

        [Column("DenNgay")]
        public DateTime? EndDate { get; set; }

        [Column("GhiChu")]
        [StringLength(50)]
        public string Description { get; set; }
    }
}
