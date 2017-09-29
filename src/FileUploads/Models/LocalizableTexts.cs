using System;
using System.Collections.Generic;

namespace FileUploads.Models
{
    public partial class LocalizableTexts
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string Scope { get; set; }
        public string Description { get; set; }
    }
}
