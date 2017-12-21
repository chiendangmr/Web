using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HD.TVADOld.Entities.Entities
{
    [Table("tblGiamGiaPhuLucHopDong")]
    public class DiscountAnnexContractPartner
    {
        [Column("IDPhuLucHopDong")]
        public int AnnexContractId { get; set; }

        [ForeignKey(nameof(AnnexContractId))]
        public AnnexContractPartner AnnexContract { get; set; }

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
