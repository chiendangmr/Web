using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HD.TVAD.Entities.Entities.MediaAsset
{
    /// <summary>
    /// Content type
    /// </summary>
    [Table("ContentTypes", Schema = "Asset")]
    public class ContentType
    {
        /// <summary>
        /// Id
        /// </summary>
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

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
        /// Is broadcast clip
        /// </summary>
        public bool IsBroadcast { get; set; }

        /// <summary>
        /// Indexing in list
        /// </summary>
        public bool IsIndexing { get; set; }

        /// <summary>
        /// Index on view
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// Contents
        /// </summary>
        [ForeignKey(nameof(Content.TypeId))]
        public ICollection<Content> Contents { get; } = new HashSet<Content>();
    }
}
