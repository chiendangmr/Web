using System;
using System.Collections.Generic;

namespace FileUploads.Models
{
    public partial class SceneComment
    {
        public Guid Id { get; set; }
        public Guid SceneId { get; set; }
        public Guid? UserId { get; set; }
        public string Text { get; set; }
        public DateTimeOffset LastEdited { get; set; }

        public virtual Scene Scene { get; set; }
    }
}
