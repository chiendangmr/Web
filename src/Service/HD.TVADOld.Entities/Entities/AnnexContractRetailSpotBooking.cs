using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HD.TVADOld.Entities.Entities
{
    [Table("tblPhatSongHopDongThuLe")]
    public class AnnexContractRetailSpotBooking
    {
        [Column("IdPhatSong")]
        [Key]
        public long Id { get; set; }

        [Column("CutID")]
        public long SpotId { get; set; }

        [ForeignKey(nameof(SpotId))]
        public Spot Spot { get; set; }

        [Column("ThuTu")]
        public decimal Index { get; set; }

        [Column("IDHopDong")]
        public int AnnexContractId { get; set; }

        [Column("MaBang")]
        public string ContentCode { get; set; }

        public AnnexContractRetailContent AnnexContractContent { get; set; }

        [Column("DuyetPhatSong")]
        public bool? Approve { get; set; }
    }
}
