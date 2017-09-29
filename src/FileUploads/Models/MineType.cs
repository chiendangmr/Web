using System;
using System.Collections.Generic;

namespace FileUploads.Models
{
    public partial class MineType
    {
        public MineType()
        {
            Asset = new HashSet<Asset>();
            AssetLocator = new HashSet<AssetLocator>();
        }

        public string InternetMediaType { get; set; }
        public string Name { get; set; }
        public string FileExtension { get; set; }
        public string Reference { get; set; }

        public virtual ICollection<Asset> Asset { get; set; }
        public virtual ICollection<AssetLocator> AssetLocator { get; set; }
    }
}
