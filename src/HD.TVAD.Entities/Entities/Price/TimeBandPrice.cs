using HD.TVAD.Entities.Entities.System;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HD.TVAD.Entities.Entities.Price
{
    /// <summary>
    /// Prices for timeband
    /// </summary>
    [Table("TimeBandPrices", Schema = "Price")]
    public class TimeBandPrice
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
        /// Spotblock id
        /// </summary>
        public Guid? SpotBlockId { get; set; }

        /// <summary>
        /// Spot block
        /// </summary>
        [ForeignKey(nameof(SpotBlockId))]
        public SpotBlock SpotBlock { get; set; }

        /// <summary>
        /// Start date for apply
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Price
        /// </summary>
        public decimal Price { get; set; }
    }
}
