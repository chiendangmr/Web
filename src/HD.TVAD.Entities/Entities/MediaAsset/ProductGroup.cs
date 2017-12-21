using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HD.TVAD.Entities.Entities.MediaAsset
{
    [Table("ProductGroups", Schema = "Asset")]
    public class ProductGroup
    {
        /// <summary>
        /// Id
        /// </summary>
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Code
        /// </summary>
        [Required]
        [StringLength(256)]
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
        /// Id of parent
        /// </summary>
        public Guid? ParentId { get; set; }

        /// <summary>
        /// Parent
        /// </summary>
        [ForeignKey(nameof(ParentId))]
        public ProductGroup Parent { get; set; }

        /// <summary>
        /// Chidrens
        /// </summary>
        [ForeignKey(nameof(ParentId))]
        public ICollection<ProductGroup> Chidrens { get; } = new HashSet<ProductGroup>();

        /// <summary>
        /// Contents
        /// </summary>
        [ForeignKey(nameof(Content.ProductGroupId))]
        public ICollection<Content> Contents { get; } = new HashSet<Content>();
    }
}
