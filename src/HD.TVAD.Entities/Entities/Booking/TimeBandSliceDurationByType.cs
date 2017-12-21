using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HD.TVAD.Entities.Entities.Booking
{
    [Table("TimeBandSliceDurationByTypes", Schema = "Booking")]
    public class TimeBandSliceDurationByType
    {
        /// <summary>
        /// Id
        /// </summary>
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Id of timebandslice duration
        /// </summary>
        public Guid TimeBandSliceDurationId { get; set; }

        /// <summary>
        /// Timeband slice duration
        /// </summary>
        [ForeignKey(nameof(TimeBandSliceDurationId))]
        public TimeBandSliceDuration DurationBase { get; set; }

        /// <summary>
        /// Id of booking type
        /// </summary>
        public BookingTypeEnum TypeId { get; set; }

        /// <summary>
        /// Booking type
        /// </summary>
        [ForeignKey(nameof(TypeId))]
        public BookingType BookingType { get; set; }

        /// <summary>
        /// Duration by seconds
        /// </summary>
        public int Duration { get; set; }
    }
}
