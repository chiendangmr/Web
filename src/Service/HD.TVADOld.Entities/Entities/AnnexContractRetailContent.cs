using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HD.TVADOld.Entities.Entities
{
    [Table("tblChiTietHopDongThuLe")]
    public class AnnexContractRetailContent
    {
        [Column("IDHopDong")]
        public int AnnexContractId { get; set; }

        [ForeignKey(nameof(AnnexContractId))]
        public AnnexContractRetail AnnexContract { get; set; }

        [Column("MaBang")]
        [Required]
        public string ContentCode { get; set; }

        [ForeignKey(nameof(ContentCode))]
        public Content Content { get; set; }

        [Column("NoiDung")]
        public string Contents { get; set; }

        [Column("MaThongTinDonGian")]
        public RetailTypeEnum RetailTypeId { get; set; }

        [ForeignKey(nameof(RetailTypeId))]
        public RetailType RetailType { get; set; }

        [Column("DonGia")]
        public decimal? Price { get; set; }
        
        public ICollection<AnnexContractRetailSpotBooking> Bookings { get; } = new HashSet<AnnexContractRetailSpotBooking>();
    }
}
