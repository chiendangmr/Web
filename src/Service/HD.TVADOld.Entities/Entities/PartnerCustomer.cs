using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HD.TVADOld.Entities.Entities
{
    [Table("tblKhachHang")]
    public class PartnerCustomer
    {
        [Column("IDKhachHang")]
        [Key]
        public int Id { get; set; }

        [Column("MaKhachHang")]
        [StringLength(20)]
        public string Code { get; set; }

        [Column("TenKhachHang")]
        [StringLength(100)]
        public string Name { get; set; }

        [Column("SoDienThoai")]
        [StringLength(20)]
        public string PhoneNumber { get; set; }

        [Column("SoFax")]
        [StringLength(20)]
        public string FaxNumber { get; set; }

        [Column("DiaChi")]
        [StringLength(200)]
        public string Address { get; set; }

        [Column("NguoiDaiDien")]
        [StringLength(50)]
        public string RepresentivePerson { get; set; }

        [Column("ChucVu")]
        [StringLength(20)]
        public string PositionOfRepresentivePerson { get; set; }

        [Column("KieuKhachHang")]
        public PartnerCustomerTypeEnum? Type { get; set; }

        [Column("SoTaiKhoan")]
        [StringLength(20)]
        public string AccountNumber { get; set; }

        [Column("MaSoThue")]
        [StringLength(20)]
        public string TaxNumber { get; set; }

        [ForeignKey(nameof(AnnexContractPartner.CustomerId))]
        public ICollection<AnnexContractPartner> AnnexContracts { get; } = new HashSet<AnnexContractPartner>();

        [ForeignKey(nameof(DiscountPartnerCustomer.CustomerId))]
        public ICollection<DiscountPartnerCustomer> Discounts { get; } = new HashSet<DiscountPartnerCustomer>();
    }

    public enum PartnerCustomerTypeEnum : int
    {
        Permanent = 1,
        NoPermanent = 2
    }
}
