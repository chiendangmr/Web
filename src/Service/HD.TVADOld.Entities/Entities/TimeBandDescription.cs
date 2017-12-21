using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HD.TVADOld.Entities.Entities
{
    /// <summary>
    /// Timeband description by date
    /// </summary>
    [Table("tblGhiChuMaGio")]
    public class TimeBandDescription
    {
        /// <summary>
        /// Timeband Id
        /// </summary>
        [Column("IDMaGio")]
        public int TimeBandId { get; set; }

        /// <summary>
        /// Timeband
        /// </summary>
        [ForeignKey(nameof(TimeBandId))]
        public TimeBand TimeBand { get; set; }

        /// <summary>
        /// Start date
        /// </summary>
        [Column("TuNgay")]
        public DateTime StartDate { get; set; }

        /// <summary>
        /// End date
        /// </summary>
        [Column("DenNgay")]
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        [Column("GhiChu")]
        public string Description { get; set; }
    }
}
