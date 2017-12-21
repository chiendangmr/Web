using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HD.TVAD.Entities.Entities.System
{
    /// <summary>
    /// Time of timeband on day
    /// </summary>
    [Table("TimeBandTimes", Schema = "System")]
    public class TimeBandTime
    {
        /// <summary>
        /// Id
        /// </summary>
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        
        /// <summary>
        /// Timeband id
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
        /// Startime of day
        /// </summary>
        public TimeSpan StartTimeOfDay { get; set; }

        /// <summary>
        /// Duration by seconds
        /// </summary>
        public int Duration { get; set; }
    }
}
