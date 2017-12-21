using HD.TVAD.Entities.Entities.MediaAsset;
using HD.TVAD.Entities.Entities.Price;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HD.TVAD.Entities.Entities.Booking
{
    [Table("AnnexContractAssets", Schema = "Booking")]
    public class AnnexContractContent
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid AnnexContractId { get; set; }

        [ForeignKey(nameof(AnnexContractId))]
        public AnnexContract AnnexContract { get; set; }

        public Guid ContentId { get; set; }

        [ForeignKey(nameof(ContentId))]
        public Content Content { get; set; }

        public Guid PriceTypeDetailId { get; set; }

        [ForeignKey(nameof(PriceTypeDetailId))]
        public PriceTypeDetail PriceTypeDetail { get; set; }

        public string Contents { get; set; }
        
        public decimal? Price { get; set; }

        [ForeignKey(nameof(SpotBooking.AnnexContractContentId))]
        public ICollection<SpotBooking> Bookings { get; } = new HashSet<SpotBooking>();
    }
}
