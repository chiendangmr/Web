using System;
using System.Collections.Generic;

namespace HD.TVAD.ApplicationCore.Entities
{
    public partial class FileDetail
    {
        public FileDetail()
        {
            FileDetailLocations = new HashSet<FileDetailLocation>();
        }

        public Guid Id { get; set; }
        public Guid FileId { get; set; }
        public int Index { get; set; }

        public virtual ICollection<FileDetailLocation> FileDetailLocations { get; set; }
        public virtual FileInStorage File { get; set; }
    }
}
