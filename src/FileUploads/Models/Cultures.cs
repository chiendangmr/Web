using System;
using System.Collections.Generic;

namespace FileUploads.Models
{
    public partial class Cultures
    {
        public string Name { get; set; }
        public string Parent { get; set; }
        public bool Disabled { get; set; }

        public virtual Cultures ParentNavigation { get; set; }
        public virtual ICollection<Cultures> InverseParentNavigation { get; set; }
    }
}
