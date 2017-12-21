using HD.TVAD.Entities.Entities.Contract;
using HD.TVAD.Entities.Entities.Price;
using HD.TVAD.Entities.Entities.System;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HD.TVAD.Entities.Entities.Booking
{
    [Table("AnnexContractPartners", Schema = "Booking")]
    public class AnnexContractPartner
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [ForeignKey(nameof(Id))]
        public AnnexContract AnnexContractBase { get; set; }

        public DateTime SignDate { get; set; }

        public string ScheduleCampaign { get; set; }

        public string Content { get; set; }

        public Guid? SponsorProgramId { get; set; }

        [ForeignKey(nameof(SponsorProgramId))]
        public SponsorProgram SponsorProgram { get; set; }

        public SponsorTypeEnum? SponsorTypeId { get; set; }

        [ForeignKey(nameof(SponsorTypeId))]
        public SponsorType SponsorType { get; set; }

        [ForeignKey(nameof(AnnexContractPartnerPriceAtSignDate.AnnexContractId))]
        public ICollection<AnnexContractPartnerPriceAtSignDate> PriceAtSignDates { get; } = new HashSet<AnnexContractPartnerPriceAtSignDate>();

        [ForeignKey(nameof(AnnexContractPrice.AnnexContractId))]
        public ICollection<AnnexContractPrice> Prices { get; } = new HashSet<AnnexContractPrice>();

        public int? OldId { get; set; }

        public AnnexContractPartner()
        {
            AnnexContractBase = new AnnexContract
            {
                Id = this.Id,
                AnnexContractPartner = this
            };
        }
    }
}
