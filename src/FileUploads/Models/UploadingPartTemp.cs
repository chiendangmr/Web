using System;
using System.Collections.Generic;

namespace FileUploads.Models
{
    public partial class UploadingPartTemp
    {
        public Guid Id { get; set; }
        public Guid UploadingPartId { get; set; }
        public string Name { get; set; }
        public Guid LocationAccessZoneId { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public int Status { get; set; }

        public virtual UploadingPart UploadingPart { get; set; }
    }
}
