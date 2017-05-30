using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnAir.Models
{
    public class ItemViewModel
    {
        public string ProgramName { get; set; }
        public string FileName { get; set; }
        public string StartTime { get; set; }
        public string TCIn { get; set; }
        public string TCOut { get; set; }
        public string Duration { get; set; }
    }
}
