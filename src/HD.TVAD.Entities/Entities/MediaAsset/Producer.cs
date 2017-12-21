using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HD.TVAD.Entities.Entities.MediaAsset
{
    /// <summary>
    /// Producer of product
    /// </summary>
    [Table("Producers", Schema = "Asset")]
    public class Producer
    {
        /// <summary>
        /// Id
        /// </summary>
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Parent producer
        /// </summary>
        public Guid? ParentId { get; set; }

        /// <summary>
        /// Parent
        /// </summary>
        [ForeignKey(nameof(ParentId))]
        public Producer Parent { get; set; }

        /// <summary>
        /// Childrens
        /// </summary>
        [ForeignKey(nameof(ParentId))]
        public ICollection<Producer> Childrens { get; } = new HashSet<Producer>();

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
        [ForeignKey(nameof(Content.ProducerId))]
        public ICollection<Content> Contents { get; } = new HashSet<Content>();
    }
}
