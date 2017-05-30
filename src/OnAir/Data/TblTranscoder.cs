using System;
using System.Collections.Generic;

namespace OnAir.Data
{
    public partial class TblTranscoder
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Ip { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string Directory1 { get; set; }
        public string Directory2 { get; set; }
        public int Status { get; set; }
        public int Priority { get; set; }
        public int Port { get; set; }
    }
}
