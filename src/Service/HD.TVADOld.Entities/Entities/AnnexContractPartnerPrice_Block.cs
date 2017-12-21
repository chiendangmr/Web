using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HD.TVADOld.Entities.Entities
{
    [Table("tblBlockApDungGiaRiengPhuLuc")]
    public class AnnexContractPartnerPrice_Block
    {
        [Column("IDPhuLucHopDong")]
        public int AnnexContractId { get; set; }

        [Column("NgayBatDau")]
        public DateTime StartDate { get; set; }

        public AnnexContractPartnerPrice AnnexContractPartnerPrice { get; set; }

        [Column("ThoiLuong")]
        public int BlockDuration { get; set; }

        [Column("DonGia")]
        public decimal Price { get; set; }
    }
}
