using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HD.TVAD.Entities.Entities.MediaAsset
{
    /// <summary>
    /// Register content
    /// </summary>
    [Table("Registers", Schema = "Asset")]
    public class Register
    {
        /// <summary>
        /// Id
        /// </summary>
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Code for auto create content code
        /// </summary>
        [StringLength(10)]
        public string Code { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        [Required]
        [StringLength(256)]
        public string Name { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Contents
        /// </summary>
        [ForeignKey(nameof(Content.RegisterId))]
        public ICollection<Content> Contents { get; } = new HashSet<Content>();

        /// <summary>
        /// Id in old system
        /// </summary>
        public int? OldId { get; set; }
    }
}
