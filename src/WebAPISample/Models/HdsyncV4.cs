using System;
using System.Collections.Generic;

namespace HDAutomationWebAPI.Models
{
    public partial class HdsyncV4
    {
        public HdsyncV4()
        {
            HdsyncV4InforTape = new HashSet<HdsyncV4InforTape>();
            HdsyncV4TblAfdtypes = new HashSet<HdsyncV4TblAfdtypes>();
            HdsyncV4TblClipTypes = new HashSet<HdsyncV4TblClipTypes>();
            HdsyncV4TblSectors = new HashSet<HdsyncV4TblSectors>();
        }

        public int IdDatabase { get; set; }
        public string Name { get; set; }

        public virtual ICollection<HdsyncV4InforTape> HdsyncV4InforTape { get; set; }
        public virtual ICollection<HdsyncV4TblAfdtypes> HdsyncV4TblAfdtypes { get; set; }
        public virtual ICollection<HdsyncV4TblClipTypes> HdsyncV4TblClipTypes { get; set; }
        public virtual ICollection<HdsyncV4TblSectors> HdsyncV4TblSectors { get; set; }
    }
}
