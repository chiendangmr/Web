using System;
using System.Collections.Generic;

namespace FileUploads.Models
{
    public partial class FileDetailLocations
    {
        public Guid Id { get; set; }
        public Guid FileDetailId { get; set; }
        public Guid LocationId { get; set; }
        public string FileName { get; set; }

        public virtual FileDetails FileDetail { get; set; }
        public virtual Locations Location { get; set; }
    }
}
