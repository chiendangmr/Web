using System;
using System.Collections.Generic;

namespace OnAir.Data
{
    public partial class Cluster
    {
        public long ClusterId { get; set; }
        public string Name { get; set; }
        public int ListId { get; set; }
        public long? ParentClusterId { get; set; }

        public virtual PlayList List { get; set; }
        public virtual Cluster ParentCluster { get; set; }
        public virtual ICollection<Cluster> InverseParentCluster { get; set; }
    }
}
