using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HD.TVADOld.Entities.Entities
{
    [Table("tblGiamGiaKhachHang")]
    public class DiscountPartnerCustomer
    {
        [Column("IDKhachHang")]
        public int CustomerId { get; set; }

        [ForeignKey(nameof(CustomerId))]
        public PartnerCustomer Customer { get; set; }

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
