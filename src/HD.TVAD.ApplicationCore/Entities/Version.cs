using System;
using System.Collections.Generic;

namespace HD.TVAD.ApplicationCore.Entities
{
    public partial class Version
    {
        public Guid Id { get; set; }
        public Guid AssetId { get; set; }
        public Guid SceneId { get; set; }
        public int Versions { get; set; }
        public bool Active { get; set; }
        public DateTime CreateTime { get; set; }

        public virtual Content Asset { get; set; }
        public virtual Scene Scene { get; set; }
    }
}
