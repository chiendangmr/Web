using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HD.TVADOld.Entities.Entities
{
    [Table("tblBang")]
    public class Content
    {
        public int Id { get; set; }

        [Column("MaBang")]
        [Key]
        [StringLength(20)]
        public string Code { get; set; }

        [Column("TenSanPham")]
        [StringLength(100)]
        public string ProductName { get; set; }

        [Column("MauBang")]
        public string ProductModel { get; set; }

        [Column("ThoiLuong")]
        public int BlockDuration { get; set; }

        [Column("MaDonViGui")]
        public int? RegisterId { get; set; }

        [ForeignKey(nameof(RegisterId))]
        public Register Register { get; set; }

        [Column("TenNhaSanXuat")]
        public string ProducerName { get; set; }

        [Column("NgayNhan")]
        public DateTime? CreateTime { get; set; }

        [Column("NgayKetThuc")]
        public DateTime? EndDate { get; set; }

        [Column("TCKTPhatSongOK")]
        public bool? QualityApprove { get; set; }

        [Column("GhiChuTCKT")]
        public string QualityApproveComment { get; set; }

        [Column("NDPhatSongOK")]
        public bool? ContentApprove { get; set; }

        [Column("GhiChuNDPhatSong")]
        public string ContentApproveComment { get; set; }

        [Column("KetQuaDuyet")]
        public ContentApproveEnum? Approve { get; set; }

        [Column("TamDuyetDen")]
        public DateTime? ApproveEndDate { get; set; }

        [Column("GhiChuKetQuaDuyet")]
        public string ApproveComment { get; set; }

        [Column("NgayDuyetCuoi")]
        public DateTime? ApproveTime { get; set; }

        [ForeignKey(nameof(ContentTimeBandLock.ContentCode))]
        public ICollection<ContentTimeBandLock> TimeBandLocks { get; } = new HashSet<ContentTimeBandLock>();

        [ForeignKey(nameof(ContentChannelLock.ContentCode))]
        public ICollection<ContentChannelLock> ChannelLocks { get; } = new HashSet<ContentChannelLock>();

        [ForeignKey(nameof(ContentChannelLock_TimeBandNoLock.ContentCode))]
        public ICollection<ContentChannelLock_TimeBandNoLock> ChannelLock_TimeBandNoLocks { get; } = new HashSet<ContentChannelLock_TimeBandNoLock>();

        [ForeignKey(nameof(AnnexContractPartnerContent.ContentCode))]
        public ICollection<AnnexContractPartnerContent> AnnexContractPartners { get; } = new HashSet<AnnexContractPartnerContent>();

        [ForeignKey(nameof(AnnexContractRetailContent.ContentCode))]
        public ICollection<AnnexContractRetailContent> AnnexContractRetails { get; } = new HashSet<AnnexContractRetailContent>();
    }

    public enum ContentApproveEnum : int
    {
        None = 0,
        Approve = 1,
        NotApprove = 2,
        TemporaryApprove = 3
    }
}
