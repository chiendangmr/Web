using System;
using System.Collections.Generic;

namespace FileUploads.Models
{
    public partial class Logs
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public Guid? UserId { get; set; }
        public string UserName { get; set; }
        public string DataId { get; set; }
        public string DataName { get; set; }
        public string Action { get; set; }
        public string Content { get; set; }
    }
}
