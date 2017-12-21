using System;
using System.Collections.Generic;

namespace HD.TVAD.ApplicationCore.Entities.MediaAsset
{
    public partial class SceneComment
    {
        public SceneComment()
        {
            
        }
        public Guid Id { get; set; }
        public Guid SceneId { get; set; }
        public Guid? UserId { get; set; }
        public string Text { get; set; }
        public DateTime LastEdited { get; set; }

        public virtual Scene Scene { get; set; }
    }
}
