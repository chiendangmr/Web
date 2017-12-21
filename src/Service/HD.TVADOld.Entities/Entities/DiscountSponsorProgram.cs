using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HD.TVADOld.Entities.Entities
{
    [Table("tblGiamGiaChuongTrinhTaiTro")]
    public class DiscountSponsorProgram
    {
        [Column("IDChuongTrinh")]
        public int SponsorProgramId { get; set; }

        [ForeignKey(nameof(SponsorProgramId))]
        public SponsorProgram SponsorProgram { get; set; }

        [Column("NgayBatDau")]
        public DateTime StartDate { get; set; }

        [Column("NgayKetThuc")]
        public DateTime? EndDate { get; set; }

        [Column("TiLeGiam")]
        public decimal Rate { get; set; }

        [Column("GhiChu")]
        public string Description { get; set; }
    }
}
