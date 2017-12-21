using System;
using System.Collections.Generic;

namespace HD.TVAD.ApplicationCore.Entities
{
    public partial class File
    {
        public File()
        {
            AssetDocumentFiles = new HashSet<AssetDocumentFile>();
            Origins = new HashSet<Origin>();
            SceneFiles = new HashSet<SceneFile>();
        }

        public Guid Id { get; set; }
        public int FileTypeId { get; set; }
        public DateTime CreateTime { get; set; }

        public virtual ICollection<AssetDocumentFile> AssetDocumentFiles { get; set; }
        public virtual FileContent FileContents { get; set; }
        public virtual FileInStorage FileInStorages { get; set; }
        public virtual ICollection<Origin> Origins { get; set; }
        public virtual ICollection<SceneFile> SceneFiles { get; set; }
        public virtual FileType FileType { get; set; }
    }
}
