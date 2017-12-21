using System;
using System.Collections.Generic;

namespace HD.TVAD.ApplicationCore.Entities
{
    public partial class Areas
    {
        public Areas()
        {
         //   Assets = new HashSet<Asset>();
        }

        public Guid Id { get; set; }
        public Guid? ParentId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Index { get; set; }

   //     public virtual ICollection<Asset> Assets { get; set; }
    }
}
