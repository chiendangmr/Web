using HD.TVAD.Entities.Entities.MediaAsset;
using HD.TVAD.Entities.Entities.System;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HD.TVAD.Entities.Entities.Booking
{
    [Table("ContentTimeBandLocks", Schema = "Booking")]
    public class ContentTimeBandLock
    {
        /// <summary>
        /// Id
        /// </summary>
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        
        /// <summary>
        /// Id of content
        /// </summary>
        public Guid ContentId { get; set; }

        /// <summary>
        /// Content
        /// </summary>
        [ForeignKey(nameof(ContentId))]
        public Content Content { get; set; }

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
        /// Start date apply
        /// </summary>
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// End date apply
        /// </summary>
        public DateTime? EndDate { get; set; }
    }
}
