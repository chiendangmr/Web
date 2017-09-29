using System;
using System.Collections.Generic;

namespace FileUploads.Models
{
    public partial class Producers
    {
        public Producers()
        {
            Content = new HashSet<Content>();
        }

        public Guid Id { get; set; }
        public Guid? ParentId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Content> Content { get; set; }
        public virtual Producers Parent { get; set; }
        public virtual ICollection<Producers> InverseParent { get; set; }
    }
}
