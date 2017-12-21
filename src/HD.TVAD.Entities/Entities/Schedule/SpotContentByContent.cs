using HD.TVAD.Entities.Entities.MediaAsset;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HD.TVAD.Entities.Entities.Schedule
{
    [Table("SpotAssetByAssets", Schema = "Schedule")]
    public class SpotContentByContent
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [ForeignKey(nameof(Id))]
        public SpotContent BaseSpotContent { get; set; }

        [Column("AssetId")]
        public Guid ContentId { get; set; }

        [ForeignKey(nameof(ContentId))]
        public Content Content { get; set; }

        public SpotContentByContent()
        {
            BaseSpotContent = new SpotContent
            {
                Id = this.Id,
                ByContent = this
            };
        }
    }
}
