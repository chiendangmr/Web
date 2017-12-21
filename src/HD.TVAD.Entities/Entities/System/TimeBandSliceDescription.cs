using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HD.TVAD.Entities.Entities.System
{
    /// <summary>
    /// Description of timeband slice
    /// </summary>
    [Table("TimeBandSliceDescriptions", Schema = "System")]
    public class TimeBandSliceDescription
    {
        /// <summary>
        /// Id
        /// </summary>
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// TimebandSlice Id
        /// </summary>
        public Guid TimeBandSliceId { get; set; }

        /// <summary>
        /// Timeband slice
        /// </summary>
        [ForeignKey(nameof(TimeBandSliceId))]
        public TimeBandSlice Slice { get; set; }

        /// <summary>
        /// Days of week
        /// </summary>
        public DayOfWeek DayOfWeeks { get; set; }

        /// <summary>
        /// Start date
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// End date
        /// </summary>
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; }
    }
}
