using HD.TVAD.Entities.Entities.Booking;
using HD.TVAD.Entities.Entities.Schedule;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HD.TVAD.Entities.Entities.System
{
    [Table("TimeBandSlices", Schema = "System")]
    public class TimeBandSlice
    {
        /// <summary>
        /// Id
        /// </summary>
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Id of timeband
        /// </summary>
        public Guid TimeBandId { get; set; }

        /// <summary>
        /// Timeband
        /// </summary>
        [ForeignKey(nameof(TimeBandId))]
        public TimeBand TimeBand { get; set; }

        /// <summary>
        /// Name of slice
        /// </summary>
        [Required]
        [StringLength(256)]
        public string Name { get; set; }

        /// <summary>
        /// Durations of slice
        /// </summary>
        [ForeignKey(nameof(TimeBandSliceDuration.TimeBandSliceId))]
        public ICollection<TimeBandSliceDuration> Durations { get; } = new HashSet<TimeBandSliceDuration>();

        /// <summary>
        /// Descriptions
        /// </summary>
        [ForeignKey(nameof(TimeBandSliceDescription.TimeBandSliceId))]
        public ICollection<TimeBandSliceDescription> Descriptions { get; } = new HashSet<TimeBandSliceDescription>();

        [ForeignKey(nameof(Spot.TimeBandSliceId))]
        public ICollection<Spot> Spots { get; } = new HashSet<Spot>();
    }
}
