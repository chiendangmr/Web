using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HD.TVADOld.Entities.Entities
{
    [Table("tblGiaThongTinDonGian")]
    public class RetailPrice
    {
        [Column("MaThongTinDonGian")]
        public RetailTypeEnum RetailTypeId { get; set; }

        [ForeignKey(nameof(RetailTypeId))]
        public RetailType RetailType { get; set; }

        [Column("NgayApDung")]
        public DateTime StartDate { get; set; }

        [Column("DonGia")]
        public decimal Price { get; set; }
    }
}
