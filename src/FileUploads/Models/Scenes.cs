using System;
using System.Collections.Generic;

namespace FileUploads.Models
{
    public partial class Scenes
    {
        public Scenes()
        {
            SceneFiles = new HashSet<SceneFiles>();
            Versions = new HashSet<Versions>();
        }

        public Guid Id { get; set; }
        public Guid OriginId { get; set; }
        public long StartFrame { get; set; }
        public long? Duration { get; set; }
        public bool? ContentApprove { get; set; }
        public string ContentNote { get; set; }
        public bool? QualityApprove { get; set; }
        public string QualityNote { get; set; }

        public virtual ICollection<SceneFiles> SceneFiles { get; set; }
        public virtual ICollection<Versions> Versions { get; set; }
        public virtual Origins Origin { get; set; }
    }
}
