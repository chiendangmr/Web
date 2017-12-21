using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HD.TVADOld.Entities.Entities
{
    [Table("tblGia_MaGio")]
    public class TimeBandPrice
    {
        [Column("IDMaGio")]
        public int TimeBandId { get; set; }

        [ForeignKey(nameof(TimeBandId))]
        public TimeBand TimeBand { get; set; }

        [Column("ThoiLuong")]
        public int BlockDuration { get; set; }

        public Block Block { get; set; }

        [Column("NgayApDung")]
        public DateTime StartDate { get; set; }

        [Column("Gia")]
        public decimal Price { get; set; }
    }
}
