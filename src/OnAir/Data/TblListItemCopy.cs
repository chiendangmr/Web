using System;
using System.Collections.Generic;

namespace OnAir.Data
{
    public partial class TblListItemCopy
    {
        public long Id { get; set; }
        public int OrderClip { get; set; }
        public string MaBang { get; set; }
        public string TenChuongTrinh { get; set; }
        public string NoiDung { get; set; }
        public string PlayTcIn { get; set; }
        public string PlayTcOut { get; set; }
        public string TcIn { get; set; }
        public string TcOut { get; set; }
        public int ListId { get; set; }
    }
}
