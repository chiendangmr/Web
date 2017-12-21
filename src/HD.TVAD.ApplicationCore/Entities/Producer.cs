using System;
using System.Collections.Generic;

namespace HD.TVAD.ApplicationCore.Entities
{
    public partial class Producer
    {
        public Producer()
        {
            Assets = new HashSet<Content>();
        }

        public Guid Id { get; set; }
        public Guid? ParentId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Content> Assets { get; set; }
        public virtual Producer Parent { get; set; }
        public virtual ICollection<Producer> InverseParent { get; set; }
    }
}
