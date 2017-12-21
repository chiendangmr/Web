using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HD.TVADOld.Entities.Entities
{
    [Table("tblChiTietPhuLucHopDong")]
    public class AnnexContractPartnerContent
    {
        [Column("IDPhuLucHopDong")]
        public int AnnexContractPartnerId { get; set; }

        [ForeignKey(nameof(AnnexContractPartnerId))]
        public AnnexContractPartner AnnexContract { get; set; }

        [Column("MaBang")]
        public string ContentCode { get; set; }

        [ForeignKey(nameof(ContentCode))]
        public Content Content { get; set; }

        [Column("GhiChu")]
        public string Contents { get; set; }

        [Column("TiLeTinh")]
        public int? PriceTypeId { get; set; }

        public ICollection<AnnexContractPartnerSpotBooking> Bookings { get; } = new HashSet<AnnexContractPartnerSpotBooking>();
    }
}