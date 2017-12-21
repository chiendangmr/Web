using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HD.TVADOld.Entities.Entities
{
    [Table("tblHopDongThuLe")]
    public class AnnexContractRetail
    {
        [Column("IDHopDong")]
        [Key]
        public int Id { get; set; }

        [Column("MaHopDong")]
        public string Code { get; set; }

        [Column("NgayLap")]
        public DateTime? ReceiveDate { get; set; }

        [Column("TenKhachHang")]
        public string CustomerName { get; set; }

        [Column("DiaChi")]
        public string Address { get; set; }
        
        [Column("TenNguoiLap")]
        public string Creater { get; set; }

        [ForeignKey(nameof(AnnexContractRetailContent.AnnexContractId))]
        public ICollection<AnnexContractRetailContent> Contents { get; } = new HashSet<AnnexContractRetailContent>();
    }
}
