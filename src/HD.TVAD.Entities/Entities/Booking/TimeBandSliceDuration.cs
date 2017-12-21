using HD.TVAD.Entities.Entities.System;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HD.TVAD.Entities.Entities.Booking
{
    [Table("TimeBandSliceDurations", Schema = "Booking")]
    public class TimeBandSliceDuration
    {
        /// <summary>
        /// Id of duration
        /// </summary>
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// If of timeband slice
        /// </summary>
        public Guid TimeBandSliceId { get; set; }

        /// <summary>
        /// Timeband slice
        /// </summary>
        [ForeignKey(nameof(TimeBandSliceId))]
        public TimeBandSlice TimeBandSlice { get; set; }

        /// <summary>
        /// Start date for apply
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// End date for apply
        /// </summary>
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// Duration by seconds
        /// </summary>
        public int Duration { get; set; }

        /// <summary>
        /// Durations by booking type
        /// </summary>
        [ForeignKey(nameof(TimeBandSliceDurationByType.TimeBandSliceDurationId))]
        public ICollection<TimeBandSliceDurationByType> DurationByTypes { get; } = new HashSet<TimeBandSliceDurationByType>();

    }
}
