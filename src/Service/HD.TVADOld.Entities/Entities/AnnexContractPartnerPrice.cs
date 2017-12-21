using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HD.TVADOld.Entities.Entities
{
    [Table("tblGiaRiengPhuLuc")]
    public class AnnexContractPartnerPrice
    {
        [Column("IDPhuLucHopDong")]
        public int AnnexContractId { get; set; }

        [ForeignKey(nameof(AnnexContractId))]
        public AnnexContractPartner AnnexContract { get; set; }

        [Column("NgayBatDau")]
        public DateTime StartDate { get; set; }

        [Column("NgayKetThuc")]
        public DateTime? EndDate { get; set; }

        [Column("GiaViTri")]
        public decimal? PositionRateUnit { get; set; }

        public ICollection<AnnexContractPartnerPrice_Block> Blocks { get; } = new HashSet<AnnexContractPartnerPrice_Block>();

        public ICollection<AnnexContractPartnerPrice_TimeBand> TimeBands { get; } = new HashSet<AnnexContractPartnerPrice_TimeBand>();
    }
}
