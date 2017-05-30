using System;
using System.Collections.Generic;

namespace OnAir.Data
{
    public partial class TblPlayListItemAuxiliaryEvent
    {
        public int ListId { get; set; }
        public long Idclip { get; set; }
        public int OrderClip { get; set; }
        public string AuxiliaryEventTime { get; set; }
        public int AuxiliaryEventTypeId { get; set; }
        public string AuxiliaryCommand { get; set; }
        public long Id { get; set; }
    }
}
