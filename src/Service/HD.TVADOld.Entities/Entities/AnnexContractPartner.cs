using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HD.TVADOld.Entities.Entities
{
    [Table("tblPhuLucHopDong")]
    public class AnnexContractPartner
    {
        [Column("IDPhuLucHopDong")]
        [Key]
        public int Id { get; set; }

        [Column("MaPhuLucHopDong")]
        public string Code { get; set; }

        [Column("IDKhachHang")]
        public int? CustomerId { get; set; }

        [ForeignKey(nameof(CustomerId))]
        public PartnerCustomer Customer { get; set; }

        [Column("NgayKy")]
        public DateTime? SignDate { get; set; }

        [Column("NgayNhan")]
        public DateTime? ReceiveDate { get; set; }

        [Column("LichDangKy")]
        public string ScheduleCampaign { get; set; }

        [Column("NoiDung")]
        public string Content { get; set; }

        [Column("LoaiPhuLuc")]
        public AnnextContractPartnerTypeEnum? Type { get; set; }

        [Column("IDChuongTrinh")]
        public int? SponsorProgramId { get; set; }

        [ForeignKey(nameof(SponsorProgramId))]
        public SponsorProgram SponsorProgram { get; set; }

        [Column("LoaiTaiTro")]
        public SponsorTypeEnum? SponsorType { get; set; }

        [Column("BookTrongPL")]
        public bool? BookInSponsor { get; set; }

        [ForeignKey(nameof(AnnexContractPartnerContent.AnnexContractPartnerId))]
        public ICollection<AnnexContractPartnerContent> Contents { get; } = new HashSet<AnnexContractPartnerContent>();

        [ForeignKey(nameof(DiscountAnnexContractPartner.AnnexContractId))]
        public ICollection<DiscountAnnexContractPartner> Discounts { get; } = new HashSet<DiscountAnnexContractPartner>();

        [ForeignKey(nameof(DiscountAnnexContractPartnerByTimeBand.AnnexContractId))]
        public ICollection<DiscountAnnexContractPartnerByTimeBand> DiscountByTimeBands { get; } = new HashSet<DiscountAnnexContractPartnerByTimeBand>();

        [ForeignKey(nameof(AnnexContractPartnerPriceAtSignDate.AnnexContractId))]
        public ICollection<AnnexContractPartnerPriceAtSignDate> PriceAtSignDates { get; } = new HashSet<AnnexContractPartnerPriceAtSignDate>();

        [ForeignKey(nameof(AnnexContractPartnerPrice.AnnexContractId))]
        public ICollection<AnnexContractPartnerPrice> Prices { get; } = new HashSet<AnnexContractPartnerPrice>();
    }

    public enum AnnextContractPartnerTypeEnum : int
    {
        None = 0,
        Booking = 1,
        Sponsor = 2
    }

    public enum SponsorTypeEnum : int
    {
        None = 0,
        Copyright = 1,
        Production = 2
    }
}
