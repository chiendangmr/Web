using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HD.Web.Delay
{
    public class AppSettings
    {
        public string connString { get; set; }
		public string SubFolder { get; set; }
		public string VideoFolder { get; set; }	
        public int ChannelId { get; set; }
        public string CaptureLowresFolder { get; set; }
        public int DisplaySubScheduleTime { get; set; }
        public string LogFolder { get; set; }        
	}

    public class Settings
    {
        public AppSettings AppSettings { get; set; }
    }
}
