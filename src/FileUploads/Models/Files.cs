using System;
using System.Collections.Generic;

namespace FileUploads.Models
{
    public partial class Files
    {
        public Files()
        {
            AssetDocumentFiles = new HashSet<AssetDocumentFiles>();
            Origins = new HashSet<Origins>();
            SceneFiles = new HashSet<SceneFiles>();
        }

        public Guid Id { get; set; }
        public int FileTypeId { get; set; }
        public DateTime CreateTime { get; set; }

        public virtual ICollection<AssetDocumentFiles> AssetDocumentFiles { get; set; }
        public virtual FileContents FileContents { get; set; }
        public virtual FileInStorages FileInStorages { get; set; }
        public virtual ICollection<Origins> Origins { get; set; }
        public virtual ICollection<SceneFiles> SceneFiles { get; set; }
        public virtual FileTypes FileType { get; set; }
    }
}
