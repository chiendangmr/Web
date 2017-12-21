using System;
using System.Collections.Generic;

namespace HD.TVAD.ApplicationCore.Entities
{
    public partial class FileDetailLocation
    {
        public Guid Id { get; set; }
        public Guid FileDetailId { get; set; }
        public Guid LocationId { get; set; }
        public string FileName { get; set; }

        public virtual FileDetail FileDetail { get; set; }
        public virtual Location Location { get; set; }
    }
}
