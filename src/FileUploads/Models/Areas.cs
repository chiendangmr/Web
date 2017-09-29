using System;
using System.Collections.Generic;

namespace FileUploads.Models
{
    public partial class Areas
    {
        public Areas()
        {
            Content = new HashSet<Content>();
        }

        public Guid Id { get; set; }
        public Guid? ParentId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Index { get; set; }

        public virtual ICollection<Content> Content { get; set; }
    }
}
