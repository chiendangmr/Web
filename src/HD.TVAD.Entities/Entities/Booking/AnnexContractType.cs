using HD.TVAD.Entities.Entities.System;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HD.TVAD.Entities.Entities.Booking
{
    [Table("AnnexContractTypes", Schema = "Booking")]
    public class AnnexContractType
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
        public AnnexContractType Parent { get; set; }

        /// <summary>
        /// Chidrens
        /// </summary>
        [ForeignKey(nameof(ParentId))]
        public ICollection<AnnexContractType> Chidrens { get; } = new HashSet<AnnexContractType>();

        /// <summary>
        /// Id of booking type
        /// </summary>
        public BookingTypeEnum BookingTypeId { get; set; }

        /// <summary>
        /// Booking type
        /// </summary>
        [ForeignKey(nameof(BookingTypeId))]
        public BookingType BookingType { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        [Required]
        [StringLength(256)]
        public string Name { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Program use this as default contract type
        /// </summary>
        [ForeignKey(nameof(SponsorProgram.DefaultContractTypeId))]
        public ICollection<SponsorProgram> SponsorProgramDefaults { get; } = new HashSet<SponsorProgram>();

        /// <summary>
        /// Annex contracts
        /// </summary>
        [ForeignKey(nameof(AnnexContract.TypeId))]
        public ICollection<AnnexContract> AnnexContracts { get; } = new HashSet<AnnexContract>();
    }
}