using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HD.TVADOld.Entities.Entities
{
    [Table("tblBang_KenhKhongPhat_MaGioNgoaiTru")]
    public class ContentChannelLock_TimeBandNoLock
    {
        [Column("MaBang")]
        [Required]
        public string ContentCode { get; set; }

        [ForeignKey(nameof(ContentCode))]
        public Content Content { get; set; }

        [Column("IDMaGio")]
        public int TimeBandId { get; set; }

        [ForeignKey(nameof(TimeBandId))]
        public TimeBand TimeBand { get; set; }
    }
}
