using System;
using System.Collections.Generic;

namespace OnAir.Data
{
    public partial class TblLiveNews
    {
        public long LiveNewsId { get; set; }
        public string Title { get; set; }
        public string Duration { get; set; }
        public string NoiDung { get; set; }
        public int? NguoiThucHien { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? NewsCategory { get; set; }
        public long? MediaId { get; set; }
    }
}
