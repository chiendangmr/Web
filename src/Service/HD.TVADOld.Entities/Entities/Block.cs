using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HD.TVADOld.Entities.Entities
{
    /// <summary>
    /// Block for calculator money
    /// </summary>
    [Table("tblBlock")]
    public class Block
    {
        /// <summary>
        /// Id of block
        /// </summary>
        [Key]
        [Column("MaBlock")]
        public int Id { get; set; }

        /// <summary>
        /// Duration of block
        /// </summary>
        [Column("GiaTriBlock")]
        public int Duration { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        [Column("MoTa")]
        [StringLength(50)]
        public string Description { get; set; }

        /// <summary>
        /// Prices
        /// </summary>
        public ICollection<TimeBandPrice> TimeBandPrices { get; } = new HashSet<TimeBandPrice>();
    }
}
