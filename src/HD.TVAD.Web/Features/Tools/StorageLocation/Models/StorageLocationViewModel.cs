using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Storage.Models
{
    public class StorageLocationViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Path { get; set; }
        public string UncPath { get; set; }
        public int StorageType { get; set; }
        public string StorageTypeDescription { get; set; }
        public Guid? StorageId { get; set; }
        public string StorageName { get; set; }
        public Guid? AssetTypeId { get; set; }
        public string AssetTypeName { get; set; }
    }
}