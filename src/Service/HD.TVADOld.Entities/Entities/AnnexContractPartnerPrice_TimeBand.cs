using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HD.TVADOld.Entities.Entities
{
    [Table("tblMaGioApDungGiaRiengPhuLuc")]
    public class AnnexContractPartnerPrice_TimeBand
    {
        [Column("IDPhuLucHopDong")]
        public int AnnexContractId { get; set; }

        [Column("NgayBatDau")]
        public DateTime StartDate { get; set; }

        public AnnexContractPartnerPrice AnnexContractPartnerPrice { get; set; }

        [Column("IDMaGio")]
        public int TimeBandId { get; set; }

        [ForeignKey(nameof(TimeBandId))]
        public TimeBand TimeBand { get; set; }
    }
}
