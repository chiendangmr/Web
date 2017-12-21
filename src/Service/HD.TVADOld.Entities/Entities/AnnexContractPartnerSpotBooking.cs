using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HD.TVADOld.Entities.Entities
{
    [Table("tblPhatSong")]
    public class AnnexContractPartnerSpotBooking
    {
        [Column("IDPhatSong")]
        [Key]
        public long Id { get; set; }

        [Column("CutID")]
        public long SpotId { get; set; }

        [ForeignKey(nameof(SpotId))]
        public Spot Spot { get; set; }

        [Column("ThuTu")]
        public decimal Index { get; set; }

        [Column("IDPhuLucHopDong")]
        public int? AnnexContractPartnerId { get; set; }

        [Column("MaBang")]
        public string ContentCode { get; set; }

        public AnnexContractPartnerContent AnnexContractPartnerContent { get; set; }

        [Column("TraTienViTri")]
        public bool? PositionCost { get; set; }

        [Column("DuyetPhatSong")]
        public bool? Approve { get; set; }

        [Column("DonGia")]
        public decimal? CardRateSet { get; set; }

        [Column("TienViTri")]
        public decimal? PositionRateSet { get; set; }

        [Column("TienKhauTru")]
        public decimal? DiscountRateSet { get; set; }

        [Column("NgayGiaGoc")]
        public DateTime? OriginalPriceDate { get; set; }

        [Column("LoaiApDung")]
        public OriginalPriceTypeEnum? OriginalPriceType { get; set; }

        [Column("PhanTramTangGiamGia")]
        public decimal? OriginalPriceRate { get; set; }
    }

    public enum OriginalPriceTypeEnum : int
    {
        All = 0,
        Increase = 1,
        Decrease = 2
    }
}
