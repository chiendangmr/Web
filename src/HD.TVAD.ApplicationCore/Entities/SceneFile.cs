using System;
using System.Collections.Generic;

namespace HD.TVAD.ApplicationCore.Entities
{
    public partial class SceneFile
    {
        public Guid Id { get; set; }
        public Guid SceneId { get; set; }
        public Guid FileId { get; set; }

        public virtual File File { get; set; }
        public virtual Scene Scene { get; set; }
    }
}
