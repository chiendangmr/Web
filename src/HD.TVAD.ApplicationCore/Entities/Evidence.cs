using System;
using System.Collections.Generic;

namespace HD.TVAD.ApplicationCore.Entities
{
    public partial class Evidence
    {
        public Evidence()
        {           
        }

        public Guid Id { get; set; }
        public Guid ChannelId { get; set; }
        public DateTimeOffset RecordTime { get; set; }
        public Guid AssetId { get; set; }
        
        public virtual Channel Channel { get; set; }
        public virtual MediaAsset.Asset Asset { get; set; }
    }
}
