using System;
using System.Collections.Generic;

namespace HD.TVAD.ApplicationCore.Entities.MediaAsset
{
    public partial class MimeType
    {
        public MimeType()
        {
            Assets = new HashSet<Asset>();
            AssetLocators = new HashSet<AssetLocator>();
        }
        public string InternetMediaType { get; set; }        
        public string Name { get; set; }
        public string FileExtension { get; set; }
        public string Reference { get; set; }

        public virtual ICollection<Asset> Assets { get; set; }
        public virtual ICollection<AssetLocator> AssetLocators { get; set; }
    }
}
