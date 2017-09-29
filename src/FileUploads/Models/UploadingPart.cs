using System;
using System.Collections.Generic;

namespace FileUploads.Models
{
    public partial class UploadingPart
    {
        public UploadingPart()
        {
            UploadingPartTemp = new HashSet<UploadingPartTemp>();
        }

        public Guid Id { get; set; }
        public Guid UploadingFileId { get; set; }
        public string Name { get; set; }
        public long Offset { get; set; }
        public long Size { get; set; }
        public int Status { get; set; }

        public virtual ICollection<UploadingPartTemp> UploadingPartTemp { get; set; }
        public virtual UploadingFile UploadingFile { get; set; }
    }
}
