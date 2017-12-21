using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HD.TVAD.Entities.Entities.System
{
    [Table("TimeBandDays", Schema = "System")]
    public class TimeBandDay
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
        /// Start date
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// End date
        /// </summary>
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// Day of weeks
        /// </summary>
        public DayOfWeek DayOfWeeks { get; set; }
    }

    public enum DayOfWeek : int
    {
        None = 0,
        Monday = 1 << 0,
        Tuesday = 1 << 1,
        Wednesday = 1 << 2,
        Thursday = 1 << 3,
        Friday = 1 << 4,
        Saturday = 1 << 5,
        Sunday = 1 << 6
    }
}
