using System;
using System.Collections.Generic;

namespace HDAutomation.Models
{
    public partial class HdsyncV4InforTape
    {
        public int IdDatabase { get; set; }
        public Guid SyncId { get; set; }
        public bool Changed { get; set; }
        public bool ChangedStorage { get; set; }

        public virtual HdsyncV4 IdDatabaseNavigation { get; set; }
        public virtual InforTape Sync { get; set; }
    }
}
