using HD.TVAD.Entities.Entities.Booking;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HD.TVAD.Entities.Entities.Price
{
    [Table("TypeDetails", Schema = "Price")]
    public class PriceTypeDetail
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public PriceTypeEnum TypeId { get; set; }

        [ForeignKey(nameof(TypeId))]
        public PriceType PriceType { get; set; }

        public string Name { get; set; }

        [ForeignKey(nameof(AnnexContractContent.PriceTypeDetailId))]
        public ICollection<AnnexContractContent> AnnexContractContents { get; } = new HashSet<AnnexContractContent>();

        // Others type

        [ForeignKey(nameof(Id))]
        public RetailType Retail { get; set; }

        [ForeignKey(nameof(Id))]
        public RateSpotBlock RateSpotBlock { get; set; }

        [ForeignKey(nameof(Id))]
        public BenefitType BenefitType { get; set; }
    }
}
