using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Models
{
    public class EvidenceViewModel
    {        
        public Guid Id { get; set; }
        public Guid? ChannelId { get; set; }
        public string ChannelName { get; set; }
        public DateTimeOffset RecordTime { get; set; }
        public Guid? AssetId { get; set; }
        public Guid? MediaAssetId { get; set; }
        public string AssetName { get; set; }
        public string FileName { get; set; }
        public string Path { get; set; }
        public DateTimeOffset UploadedDate { get; set; }
    }
}
