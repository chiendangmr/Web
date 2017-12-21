using System;
using System.Collections.Generic;

namespace HD.TVAD.ApplicationCore.Entities.MediaAsset
{
    public partial class Scene
    {
        public Scene()
        {
            SceneComments = new HashSet<SceneComment>();
        }
        public Guid Id { get; set; }
        public Guid AssetId { get; set; }
        public Guid? UserId { get; set; }
        public long StartOffset { get; set; }
        public long Duration { get; set; }
        public string Text { get; set; }
        public DateTime LastEdited { get; set; }

        public virtual Asset Asset { get; set; }
        public virtual ICollection<SceneComment> SceneComments { get; set; }
    }
}
