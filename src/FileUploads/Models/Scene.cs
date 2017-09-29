using System;
using System.Collections.Generic;

namespace FileUploads.Models
{
    public partial class Scene
    {
        public Scene()
        {
            SceneComment = new HashSet<SceneComment>();
        }

        public Guid Id { get; set; }
        public Guid AssetId { get; set; }
        public Guid? UserId { get; set; }
        public long StartOffset { get; set; }
        public long Duration { get; set; }
        public string Text { get; set; }
        public DateTimeOffset LastEdited { get; set; }

        public virtual ICollection<SceneComment> SceneComment { get; set; }
        public virtual Asset Asset { get; set; }
    }
}
