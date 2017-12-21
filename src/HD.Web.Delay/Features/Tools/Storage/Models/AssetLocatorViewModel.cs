using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Storage.Models
{   
    public class AssetLocatorViewModel
    {
        public Guid Id { get; set; }
        public Guid AssetId { get; set; }
        public string AssetName { get; set; }
        public string ContainerMineType { get; set; }
        public Guid StorageLocationId { get; set; }
        public string StorageLocationName { get; set; }
        public DateTimeOffset UploadedDate { get; set; }
        public string Path { get; set; }
        public Byte[] Revision { get; set; }
    }
}