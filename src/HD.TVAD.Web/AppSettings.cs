using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HD.Web.Delay
{
    public class AppSettings
    {
        public string ReportHost { get; set; }
		public string ProviderId { get; set; }
		public string ProfileId { get; set; }	
        public Guid AssetTypeEvidenceId { get; set; }
        public Guid AssetTypeLowresId { get; set; }
        public Guid AssetTypeTVCId { get; set; }
        public Guid AssetTypeTVCHDId { get; set; }
        public Guid AssetTypeDocsId { get; set; }
		public int DayPartTimeSpan { get; set; }


	}

    public class Settings
    {
        public AppSettings AppSettings { get; set; }
    }
}
