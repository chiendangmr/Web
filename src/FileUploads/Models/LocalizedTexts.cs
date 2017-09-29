using System;
using System.Collections.Generic;

namespace FileUploads.Models
{
    public partial class LocalizedTexts
    {
        public Guid Id { get; set; }
        public string Key { get; set; }
        public string Culture { get; set; }
        public string Scope { get; set; }
        public bool Disabled { get; set; }
        public string Value { get; set; }
    }
}
