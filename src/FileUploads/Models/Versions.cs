using System;
using System.Collections.Generic;

namespace FileUploads.Models
{
    public partial class Versions
    {
        public Guid Id { get; set; }
        public Guid AssetId { get; set; }
        public Guid SceneId { get; set; }
        public int Versions1 { get; set; }
        public bool Active { get; set; }
        public DateTime CreateTime { get; set; }

        public virtual Content Asset { get; set; }
        public virtual Scenes Scene { get; set; }
    }
}
