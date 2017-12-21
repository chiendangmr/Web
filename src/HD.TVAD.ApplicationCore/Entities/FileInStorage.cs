using System;
using System.Collections.Generic;

namespace HD.TVAD.ApplicationCore.Entities
{
    public partial class FileInStorage
    {
        public FileInStorage()
        {
            FileDetails = new HashSet<FileDetail>();
        }

        public Guid Id { get; set; }

        public virtual ICollection<FileDetail> FileDetails { get; set; }
        public virtual File IdNavigation { get; set; }
    }
}
