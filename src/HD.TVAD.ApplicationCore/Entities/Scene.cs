using System;
using System.Collections.Generic;

namespace HD.TVAD.ApplicationCore.Entities
{
    public partial class Scene
    {
        public Scene()
        {
            SceneFiles = new HashSet<SceneFile>();
            Versions = new HashSet<Version>();
        }

        public Guid Id { get; set; }
        public Guid OriginId { get; set; }
        public long StartFrame { get; set; }
        public long? Duration { get; set; }
        public bool? ContentApprove { get; set; }
        public string ContentNote { get; set; }
        public bool? QualityApprove { get; set; }
        public string QualityNote { get; set; }

        public virtual ICollection<SceneFile> SceneFiles { get; set; }
        public virtual ICollection<Version> Versions { get; set; }
        public virtual Origin Origin { get; set; }
    }
}
