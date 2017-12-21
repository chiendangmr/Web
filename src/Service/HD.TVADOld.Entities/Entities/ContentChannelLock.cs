using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HD.TVADOld.Entities.Entities
{
    [Table("tblBang_KenhKhongPhat")]
    public class ContentChannelLock
    {
        [Column("MaBang")]
        [Required]
        public string ContentCode { get; set; }

        [ForeignKey(nameof(ContentCode))]
        public Content Content { get; set; }

        [Column("MaKenh")]
        public int ChannelId { get; set; }

        [ForeignKey(nameof(ChannelId))]
        public Channel Channel { get; set; }
    }
}
