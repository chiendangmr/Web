using HD.TVAD.Entities.Entities.Booking;
using HD.TVAD.Entities.Entities.Schedule;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HD.TVAD.Entities.Entities.MediaAsset
{
    /// <summary>
    /// Content
    /// </summary>
    [Table("Content", Schema = "MediaAssets")]
    public class Content
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
        /// Name of product
        /// </summary>
        [Required]
        public string ProductName { get; set; }

        /// <summary>
        /// Model of product
        /// </summary>
        public string ProductModel { get; set; }

        /// <summary>
        /// Block duration by seconds
        /// </summary>
        public int BlockDuration { get; set; }

        /// <summary>
        /// Create time
        /// </summary>
        public DateTime CreateTime { get; set; } = DateTime.Now;

        /// <summary>
        /// End date
        /// </summary>
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// Id of content type
        /// </summary>
        public Guid TypeId { get; set; }

        /// <summary>
        /// Content type
        /// </summary>
        [ForeignKey(nameof(TypeId))]
        public ContentType Type { get; set; }

        /// <summary>
        /// Id of register
        /// </summary>
        public Guid? RegisterId { get; set; }

        /// <summary>
        /// Register
        /// </summary>
        [ForeignKey(nameof(RegisterId))]
        public Register Register { get; set; }

        /// <summary>
        /// Id of producer
        /// </summary>
        public Guid? ProducerId { get; set; }

        /// <summary>
        /// Producer
        /// </summary>
        [ForeignKey(nameof(ProducerId))]
        public Producer Producer { get; set; }

        /// <summary>
        /// Id of product group
        /// </summary>
        public Guid? ProductGroupId { get; set; }

        /// <summary>
        ///  Product group
        /// </summary>
        [ForeignKey(nameof(ProductGroupId))]
        public ProductGroup ProductGroup { get; set; }

        /// <summary>
        /// Approve state
        /// </summary>
        public bool? Approve { get; set; }

        /// <summary>
        /// End date for temporary approve
        /// </summary>
        public DateTime? ApproveEndDate { get; set; }

        /// <summary>
        /// Comment of approve
        /// </summary>
        public string ApproveComment { get; set; }

        /// <summary>
        /// Approve time
        /// </summary>
        public DateTime? ApproveTime { get; set; }

        /// <summary>
        /// Id of last model of product
        /// </summary>
        [Column("LastProductModel")]
        public Guid? LastProductModelId { get; set; }

        /// <summary>
        /// Last model of product
        /// </summary>
        [ForeignKey(nameof(LastProductModelId))]
        public Content LastProductModel { get; set; }

        /// <summary>
        /// Content with text content
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Timebands lock
        /// </summary>
        [ForeignKey(nameof(ContentTimeBandLock.ContentId))]
        public ICollection<ContentTimeBandLock> TimeBandLocks { get; } = new HashSet<ContentTimeBandLock>();

        [ForeignKey(nameof(ContentChannelLock.ContentId))]
        public ICollection<ContentChannelLock> ChannelLocks { get; } = new HashSet<ContentChannelLock>();

        [ForeignKey(nameof(AnnexContractContent.ContentId))]
        public ICollection<AnnexContractContent> AnnexContracts { get; } = new HashSet<AnnexContractContent>();

        [ForeignKey(nameof(SpotContentByContent.ContentId))]
        public ICollection<SpotContentByContent> SpotContents { get; } = new HashSet<SpotContentByContent>();

        /// <summary>
        /// Code on Old system
        /// </summary>
        public int? OldId { get; set; }
    }
}
