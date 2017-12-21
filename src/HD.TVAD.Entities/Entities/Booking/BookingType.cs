using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HD.TVAD.Entities.Entities.Booking
{
    /// <summary>
    /// Booking type object, Id in BookingTypeEnum
    /// </summary>
    [Table("BookingTypes", Schema = "Booking")]
    public class BookingType
    {
        [Key]
        public BookingTypeEnum Id { get; set; }

        /// <summary>
        /// Id of parent
        /// </summary>
        public BookingTypeEnum? ParentId { get; set; }

        /// <summary>
        /// Parent type
        /// </summary>
        [ForeignKey(nameof(ParentId))]
        public BookingType Parent { get; set; }

        /// <summary>
        /// Name of type
        /// </summary>
        [Required]
        [StringLength(256)]
        public string Name { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Durations in timebandslice
        /// </summary>
        [ForeignKey(nameof(TimeBandSliceDurationByType.TypeId))]
        public ICollection<TimeBandSliceDurationByType> TimeBandSliceDurations { get; } = new HashSet<TimeBandSliceDurationByType>();

        /// <summary>
        /// Annex contract types
        /// </summary>
        [ForeignKey(nameof(AnnexContractType.BookingTypeId))]
        public ICollection<AnnexContractType> AnnexContractTypes { get; } = new HashSet<AnnexContractType>();

        /// <summary>
        /// Annex contracts
        /// </summary>
        [ForeignKey(nameof(AnnexContract.BookingTypeId))]
        public ICollection<AnnexContract> AnnexContracts { get; } = new HashSet<AnnexContract>();

        [ForeignKey(nameof(BookingType_PriceType.BookingTypeId))]
        public ICollection<BookingType_PriceType> PriceTypes { get; } = new HashSet<BookingType_PriceType>();
    }

    public enum BookingTypeEnum : int
    {
        [Display(Name = "All")]
        All = 0,
        [Display(Name = "Booking has contract")]
        Contract = 1,
        [Display(Name = "Retail booking")]
        Retail = 2,
        [Display(Name = "Booking")]
        Contract_Booking = 3,
        [Display(Name = "Booking with sponsor")]
        Contract_Sponsor = 4,
        [Display(Name = "Booking in sponsor program")]
        Contract_Sponsor_InProgram = 5,
        [Display(Name = "Booking out sponsor program")]
        Contract_Sponsor_OutProgram = 6,
        [Display(Name = "Trailer booking")]
        Contract_Sponsor_Trailer = 7,
        [Display(Name = "Benefit")]
        Contract_Sponsor_Benefit = 8
    }
}
