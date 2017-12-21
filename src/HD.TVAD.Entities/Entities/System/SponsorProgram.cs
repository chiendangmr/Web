using HD.TVAD.Entities.Entities.Booking;
using HD.TVAD.Entities.Entities.Price;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HD.TVAD.Entities.Entities.System
{
    [Table("SponsorPrograms", Schema = "System")]
    public class SponsorProgram
    {
        /// <summary>
        /// Id
        /// </summary>
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Id of parent
        /// </summary>
        public Guid? ParentId { get; set; }

        /// <summary>
        /// Parent
        /// </summary>
        [ForeignKey(nameof(ParentId))]
        public SponsorProgram Parent { get; set; }

        /// <summary>
        /// Childrens
        /// </summary>
        [ForeignKey(nameof(ParentId))]
        public ICollection<SponsorProgram> Childrens { get; } = new HashSet<SponsorProgram>();

        /// <summary>
        /// Code of program
        /// </summary>
        [Required]
        [StringLength(256)]
        public string Code { get; set; }

        /// <summary>
        /// Name of program
        /// </summary>
        [Required]
        [StringLength(256)]
        public string Name { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// End date
        /// </summary>
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// Id of contract type default
        /// </summary>
        public Guid? DefaultContractTypeId { get; set; }

        /// <summary>
        /// Default annex contract type
        /// </summary>
        [ForeignKey(nameof(DefaultContractTypeId))]
        public AnnexContractType DefaultAnnexContractType { get; set; }

        /// <summary>
        /// Annex contract partners
        /// </summary>
        [ForeignKey(nameof(AnnexContractPartner.SponsorProgramId))]
        public ICollection<AnnexContractPartner> AnnexContractPartners { get; } = new HashSet<AnnexContractPartner>();

        /// <summary>
        /// Benefit Price apply
        /// </summary>
        [ForeignKey(nameof(BenefitPrice_SponsorProgram.SponsorProgramId))]
        public ICollection<BenefitPrice_SponsorProgram> BenefitPrices { get; } = new HashSet<BenefitPrice_SponsorProgram>();

        [ForeignKey(nameof(DiscountSponsorProgram.ProgramId))]
        public ICollection<DiscountSponsorProgram> Discounts { get; } = new HashSet<DiscountSponsorProgram>();

        /// <summary>
        /// Id in old system
        /// </summary>
        public int? OldId { get; set; }
    }
}
