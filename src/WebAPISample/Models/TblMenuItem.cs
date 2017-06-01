using System;
using System.Collections.Generic;

namespace HDAutomationWebAPI.Models
{
    public partial class TblMenuItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Href { get; set; }
        public int? Parent { get; set; }
        public int MenuOrder { get; set; }
        public bool Disabled { get; set; }
        public bool Explanded { get; set; }
        public int Rightpanel { get; set; }
        public int? LicenceId { get; set; }
        public byte[] LicenceActivated { get; set; }
    }
}
