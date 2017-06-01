using System;
using System.Collections.Generic;

namespace HDAutomationWebAPI.Models
{
    public partial class TblServerFactoryExtension
    {
        public int Id { get; set; }
        public int ServerFactoryId { get; set; }
        public string FileSourceExtension { get; set; }
        public string FileDestExtension { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ServerDirectory { get; set; }
    }
}
