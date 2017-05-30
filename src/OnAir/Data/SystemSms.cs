using System;
using System.Collections.Generic;

namespace OnAir.Data
{
    public partial class SystemSms
    {
        public long Id { get; set; }
        public string Target { get; set; }
        public string Sms { get; set; }
        public DateTime? Datecreate { get; set; }
        public DateTime? Dateresponse { get; set; }
        public string Status { get; set; }
        public int Retry { get; set; }
    }
}
