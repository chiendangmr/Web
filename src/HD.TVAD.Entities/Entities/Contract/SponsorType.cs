using HD.TVAD.Entities.Entities.Booking;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HD.TVAD.Entities.Entities.Contract
{
    [Table("SponsorTypes", Schema = "Contract")]
    public class SponsorType
    {
        [Key]
        public SponsorTypeEnum Id { get; set; }

        [Required]
        [StringLength(256)]
        public string Name { get; set; }

        [ForeignKey(nameof(AnnexContractPartner.SponsorTypeId))]
        public ICollection<AnnexContractPartner> AnnexContractPartners { get; } = new HashSet<AnnexContractPartner>();
    }

    public enum SponsorTypeEnum : int
    {
        [Display(Name = "Sponsor for buy copyright")]
        Copyright = 1,
        [Display(Name = "Sponsor for production")]
        Production = 2
    }
}
