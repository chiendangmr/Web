using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HD.TVADOld.Entities.Entities
{
    [Table("tblCuts")]
    public class Spot
    {
        [Column("CutId")]
        [Key]
        public long Id { get; set; }

        [Column("NgayPhatSong")]
        public DateTime BroadcastDate { get; set; }

        [Column("IDMaGio")]
        public int TimeBandId { get; set; }

        [Column("LatCat")]
        public int SliceId { get; set; }

        public TimeBandSlice TimeBandSlice { get; set; }

        [Column("GhiChu")]
        public string Description { get; set; }

        [ForeignKey(nameof(AnnexContractPartnerSpotBooking.SpotId))]
        public ICollection<AnnexContractPartnerSpotBooking> AnnexContractPartnerBookings { get; } = new HashSet<AnnexContractPartnerSpotBooking>();

        [ForeignKey(nameof(AnnexContractRetailSpotBooking.SpotId))]
        public ICollection<AnnexContractRetailSpotBooking> AnnexContractRetailBookings { get; } = new HashSet<AnnexContractRetailSpotBooking>();
    }
}
