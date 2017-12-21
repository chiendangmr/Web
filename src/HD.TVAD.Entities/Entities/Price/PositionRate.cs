using HD.TVAD.Entities.Entities.System;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HD.TVAD.Entities.Entities.Price
{
    /// <summary>
    /// Rate of position
    /// </summary>
    [Table("PositionRates", Schema = "Price")]
    public class PositionRate
    {
        /// <summary>
        /// Id
        /// </summary>
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Id of timeband
        /// </summary>
        public Guid? TimeBandId { get; set; }

        /// <summary>
        /// Timeband
        /// </summary>
        [ForeignKey(nameof(TimeBandId))]
        public TimeBand TimeBand { get; set; }

        /// <summary>
        /// Start date for apply
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// End date for apply
        /// </summary>
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// Rate
        /// </summary>
        public decimal Rate { get; set; }
    }
}
